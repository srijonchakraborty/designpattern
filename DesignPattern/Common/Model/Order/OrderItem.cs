using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Order
{
    public class OrderItem : IOrderItem
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public double ReceivedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public string Unit { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
    }
}
