using Common.Contracts.Order;
using Common;
using StatePattern.Contracts.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Implementation.Approval.OrderApprovalStates.PurchaseOrder
{
    public class PurchaseRejectState : IApprovalState<IOrder, OrderStatus, ApprovalStatus>
    {
        public void Process(IApprovalContext<IOrder, OrderStatus, ApprovalStatus> context, OrderStatus modelStatus, ApprovalStatus statusApproval)
        {
            context.CurrentObject.StatusApproval = statusApproval;
            context.CurrentObject.Status = modelStatus;

            // We can call repository to upsert AllApprovalHistory for current context
            //Send Reject email to IOrder creator
            var history = context.GetAllApprovalHistory();
        }
    }
}
