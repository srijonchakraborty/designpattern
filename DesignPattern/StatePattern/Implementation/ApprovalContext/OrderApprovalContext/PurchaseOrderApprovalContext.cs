using Common;
using Common.Contracts.Order;
using Common.Model.Approval;

namespace StatePattern.Implementation.ApprovalContext.OrderApprovalContext
{
    public class PurchaseOrderApprovalContext : BaseApprovalContext
    {
        public PurchaseOrderApprovalContext(IOrder currentObject) : base(currentObject)
        {

        }
        public override void ProcessToNext(ApprovalStatus from, ApprovalStatus to, OrderStatus tomodelStatus, string performBy)
        {
            var targetKey = new { From = from, To = to };
            if (CurrentApprovalState!=null && ApprovalRules.ContainsKey(targetKey))
            {
                SetHistory(from, to, performBy);
                CurrentApprovalState.Process(this, tomodelStatus, to);
            }
        }

        private void SetHistory(ApprovalStatus from, ApprovalStatus to, string performBy)
        {
            SetCurrentApprovalStatus(new ApprovalHistory<OrderStatus, ApprovalStatus>()
            {
                CreatedDate = CurrentObject.ModifiedDate,
                CreatedBy = performBy,
                CurrentApprovalStatus = to,
                CurrentModelStatus = CurrentObject.Status,
                PreviousApprovalStatus = from,
                PreviousModelStatus = CurrentObject.Status,
                ReferenceId = CurrentObject.Id,
                ReferenceType = ApprovalReferenceType.PO
            });
        }
    }
}
