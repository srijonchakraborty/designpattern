using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public static class PredefineApprovalRuleData<TStatus>
    {
        public static Dictionary<object, Func<TStatus, TStatus, TStatus>> PrepareApprovalRule()
        {
            Dictionary<object, Func<TStatus, TStatus, TStatus>> ApprovalRules = new Dictionary<object, Func<TStatus, TStatus, TStatus>>();
            ApprovalRules.Add(new { From = ApprovalStatus.Draft, To = ApprovalStatus.InReview }, (from, to) => to);
            ApprovalRules.Add(new { From = ApprovalStatus.Draft, To = ApprovalStatus.Cancel }, (from, to) => to);
            ApprovalRules.Add(new { From = ApprovalStatus.Draft, To = ApprovalStatus.Approved }, (from, to) => to);
            ApprovalRules.Add(new { From = ApprovalStatus.InReview, To = ApprovalStatus.Approved }, (from, to) => to);
            ApprovalRules.Add(new { From = ApprovalStatus.InReview, To = ApprovalStatus.Reject }, (from, to) => to);
            return ApprovalRules;
        }

        public static TStatus? CheckCondition(Dictionary<object, Func<TStatus, TStatus, TStatus>> rules, TStatus currentStatus, TStatus nextStatus)
        {
            var targetKey = new { From = currentStatus, To = nextStatus };
            if (rules.ContainsKey(targetKey))
            {
                var targetStatusDelegate = rules[targetKey];
                return targetStatusDelegate.Invoke(currentStatus, nextStatus);
            }
            else
            {
                return currentStatus;
            }
        }
    }
}
