using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class PredefineApprovalRuleData<TStatus>
    {
        private Dictionary<Func<TStatus, TStatus, bool>, Func<TStatus, TStatus, TStatus>> TransitionRules { get; } = new Dictionary<Func<TStatus, TStatus, bool>, Func<TStatus, TStatus, TStatus>>();

        
        public Dictionary<Func<TStatus, TStatus, bool>, Func<TStatus, TStatus, TStatus>> GetApprovalRule()
        {
            AddTransitionRule((fromStatus, toStatus) => fromStatus !=null 
                                                        && toStatus != null 
                                                        && fromStatus.Equals(ApprovalStatus.Draft) 
                                                        && toStatus.Equals(ApprovalStatus.InReview), (from, to) => to);

            AddTransitionRule((fromStatus, toStatus) => fromStatus != null
                                                        && toStatus != null
                                                        && fromStatus.Equals(ApprovalStatus.Draft)
                                                        && toStatus.Equals(ApprovalStatus.Cancel), (from, to) => to);

            AddTransitionRule((fromStatus, toStatus) => fromStatus != null
                                                        && toStatus != null
                                                        && fromStatus.Equals(ApprovalStatus.Draft)
                                                        && toStatus.Equals(ApprovalStatus.Approved), (from, to) => to);

            AddTransitionRule((fromStatus, toStatus) => fromStatus != null
                                                        && toStatus != null
                                                        && fromStatus.Equals(ApprovalStatus.InReview)
                                                        && toStatus.Equals(ApprovalStatus.Approved), (from, to) => to);

            AddTransitionRule((fromStatus, toStatus) => fromStatus != null
                                                        && toStatus != null
                                                        && fromStatus.Equals(ApprovalStatus.InReview)
                                                        && toStatus.Equals(ApprovalStatus.Reject), (from, to) => to);

            return TransitionRules;
        }
        private void AddTransitionRule(Func<TStatus, TStatus, bool> condition, Func<TStatus, TStatus, TStatus> targetState)
        {
            TransitionRules[condition] = targetState;
        }

        public TStatus? CheckCondition(Dictionary<Func<TStatus, TStatus, bool>, Func<TStatus, TStatus, TStatus>>  rules, TStatus currentStatus, TStatus nextStatus)
        {
            foreach (var rule in rules)
            {
                var condition = rule.Key;
                var targetState = rule.Value;
                if (condition(currentStatus, nextStatus))
                {
                    var status = targetState(currentStatus, nextStatus);
                    return status;
                }
            }
            return currentStatus;
        }

    }
}
