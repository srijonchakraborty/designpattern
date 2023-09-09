using Common.Contracts.Order;
using Common.Model.Approval;

namespace Common.Model.Order
{
    public class PurchaseOrder : IPurchaseOrder
    {
        public PurchaseOrderType POType { get; set; }
        public string TenderNo { get; set; }
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderNo { get; set; }
        public List<IOrderItem> OrderItems { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ClientEmail { get; set; }
        public double TotalAmount 
        { 
            get 
            {
              return OrderItems?.Sum(c => c.Quantity * c.Price) ?? 0;
            } 
        }
        public double ShippingFee { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double LoyaltyDiscount { get; set; }

        public double TotalCost 
        {
            get
            {
                return (TotalAmount+ ShippingFee+ TaxAmount)-(DiscountAmount+ LoyaltyDiscount);
            }
        }

        public ApprovalStatus StatusApproval { get; set; }
    }
}
