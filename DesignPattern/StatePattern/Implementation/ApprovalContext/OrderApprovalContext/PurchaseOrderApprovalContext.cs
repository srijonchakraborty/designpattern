using Common;
using Common.Contracts.Order;
using Common.Data;
using Common.Model.Approval;
using StatePattern.Contracts.Approval;
using StatePattern.Implementation.Approval.OrderApprovalStates.PurchaseOrder;
using System.Runtime.InteropServices;

namespace StatePattern.Implementation.ApprovalContext.OrderApprovalContext
{
    public class PurchaseOrderApprovalContext : BaseApprovalContext
    {
        public PurchaseOrderApprovalContext(IOrder currentObject) : base(currentObject)
        {
            SetCurrentApprovalState(GetState(currentObject.StatusApproval));
        }
        public override bool ProcessToNext(ApprovalStatus from, ApprovalStatus to, OrderStatus tomodelStatus, string performBy)
        {
            bool result = false;
            var allowedNextStatus= PredefineApprovalRuleData<ApprovalStatus>.CheckCondition(ApprovalRules,from, to);
            if (CurrentApprovalState!=null && allowedNextStatus== to)
            {
                SetHistory(from, to, performBy);
                SetCurrentApprovalState(GetState(allowedNextStatus));
                CurrentApprovalState.Process(this, tomodelStatus, to);
                result=true;
            }
            return result;
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

        private IApprovalState<IOrder, OrderStatus, ApprovalStatus> GetState(ApprovalStatus statusApproval)
        {
            if (statusApproval == ApprovalStatus.Approved)
            {
                return new PurchaseApproveState();
            }
            else if (statusApproval == ApprovalStatus.Cancel)
            {
                return new PurchaseCancelState();
            }
            else if (statusApproval == ApprovalStatus.Reject)
            {
                return new PurchaseRejectState();
            }
            else if (statusApproval == ApprovalStatus.InReview)
            {
                return new PurchaseInReviewState();
            }
            else 
            {
                return new PurchaseDraftState();
            }
        }
    }
}
