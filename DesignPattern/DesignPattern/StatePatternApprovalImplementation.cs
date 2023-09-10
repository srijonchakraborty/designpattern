using Common;
using Common.Model.Order;
using DesignPattern.Order;
using StatePattern.Implementation.ApprovalContext.OrderApprovalContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal static class StatePatternApprovalImplementation
    {
        internal static void StatePatternImplementation()
        {
            var items = OrderDataCreator.CreateData();
            var pOItems = items.OfType<PurchaseOrder>().ToList();
            var poObject = pOItems[0];

            //Set Object Staus to Initial Status
            poObject.StatusApproval=ApprovalStatus.Draft;
            poObject.Status = OrderStatus.Draft;
            var context = new PurchaseOrderApprovalContext(poObject);
            var dummyCreatedBy = Guid.NewGuid().ToString();
            var result1 = context.ProcessToNext(ApprovalStatus.Draft, ApprovalStatus.InReview, OrderStatus.Pending, dummyCreatedBy);

            var result2 = context.ProcessToNext(ApprovalStatus.InReview, ApprovalStatus.Approved, OrderStatus.Approved, dummyCreatedBy);

            var result3 = context.ProcessToNext(ApprovalStatus.Approved, ApprovalStatus.Draft, OrderStatus.Approved, dummyCreatedBy);
        }
    }
}
