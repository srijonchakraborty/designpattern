using Common.Contracts.Order;

namespace Common.Model.Order
{
    public class LC : ILC
    {
        public string BankName { get; set; }
        public string BankEmail { get; set; }
        public string Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderNo { get; set; }
        public List<IOrderItem> OrderItems { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
