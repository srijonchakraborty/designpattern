using Common;
using Common.Constrains;
using Common.Contracts.Order;
using Common.Data;
using Common.Model.Approval;
using Common.Model.Order;
using StatePattern.Contracts.Approval;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Implementation.ApprovalContext.OrderApprovalContext
{
    public abstract class BaseApprovalContext : IApprovalContext<IOrder, OrderStatus, ApprovalStatus>
    {
        protected Dictionary<object, Func<ApprovalStatus, ApprovalStatus, ApprovalStatus>> ApprovalRules = PredefineApprovalRuleData<ApprovalStatus>.PrepareApprovalRule();
        protected List<ApprovalHistory<OrderStatus, ApprovalStatus>> ApprovalHistoryList = new List<ApprovalHistory<OrderStatus, ApprovalStatus>>();
        public IOrder CurrentObject => _currentObject;
        private readonly IOrder _currentObject;

        public IApprovalState<IOrder, OrderStatus, ApprovalStatus> CurrentApprovalState => _currentApprovalState;
        private IApprovalState<IOrder, OrderStatus, ApprovalStatus> _currentApprovalState;
        protected BaseApprovalContext(IOrder currentObject)
        {
            _currentObject = currentObject;
            //_currentApprovalState = new DraftState<T>();
        }
        public abstract void ProcessToNext(ApprovalStatus from, ApprovalStatus to, OrderStatus tomodelStatus, string performBy);
        public void SetCurrentApprovalState(IApprovalState<IOrder, OrderStatus, ApprovalStatus> currentApprovalState)
        {
            _currentApprovalState = currentApprovalState;
        }
        public virtual List<ApprovalHistory<OrderStatus, ApprovalStatus>> GetAllApprovalHistory()
        {
            return ApprovalHistoryList;
        }
        protected virtual void SetCurrentApprovalStatus(ApprovalHistory<OrderStatus, ApprovalStatus> approvalHistory)
        {
            ApprovalHistoryList.Add(approvalHistory);
        }
    }
}
