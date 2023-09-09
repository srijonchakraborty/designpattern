using Common.Contracts.Order;
using Common;
using StatePattern.Contracts.Approval;

namespace StatePattern.Implementation.Approval.OrderApprovalStates.PurchaseOrder
{
    public class PurchaseApproveState : IApprovalState<IOrder, OrderStatus, ApprovalStatus>
    {
        public void Process(IApprovalContext<IOrder, OrderStatus, ApprovalStatus> context, OrderStatus modelStatus, ApprovalStatus statusApproval)
        {
            context.CurrentObject.StatusApproval = statusApproval;
            context.CurrentObject.Status = modelStatus;

            // We can call repository to upsert AllApprovalHistory for current context
            var history = context.GetAllApprovalHistory();
        }
    }
}
