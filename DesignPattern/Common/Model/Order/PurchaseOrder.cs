using Common.Contracts.Order;

namespace Common.Model.Order
{
    public class PurchaseOrder : IPurchaseOrder
    {
        public PurchaseOrderType POType { get; set; }
        public string TenderNo { get; set; }
        public string Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderNo { get; set; }
        public List<IOrderItem> Orders { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
