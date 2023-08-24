using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Order
{
    public interface IOrder
    {
        string Id { get; set; }
        OrderStatus OrderStatus { get; set; }
        string OrderNo { get; set; }
        List<IOrderItem> Orders { get; set; }
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }

    public interface IOrderItem
    {
        string Id { get; set; }
        string OrderId { get; set; }
        string ItemId { get; set; }
        string ItemName { get; set; }
        double Quantity { get; set; }
        double Price { get; set; }
        double ReceivedQuantity { get; set; }
        double RejectedQuantity { get; set; }
        string Unit { get; set; }
        string SupplierName { get; set; }
        string SupplierEmail { get; set; }
    }
}
