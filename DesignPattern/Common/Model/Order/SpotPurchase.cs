using Common.Contracts.Order;

namespace Common.Model.Order
{
    public class SpotPurchase : ISpotPurchase
    {
        public string InvoiceCashMemoNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderNo { get; set; }
        public List<IOrderItem> OrderItems { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ClientEmail { get; set; }
        public ApprovalStatus StatusApproval { get; set; }
    }
}
