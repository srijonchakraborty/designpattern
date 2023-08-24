using BuilderPattern.BuilderConcrete.OrderBuilder;
using BuilderPattern.BuilderDirectors.OrderDirector;
using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model.Order;

namespace DesignPattern.Order
{
    internal static class GeneratePurchaseOrder
    {
        internal static List<IOrder> GetPOItems()
        {
            List<IOrder> orders = new List<IOrder>();
            PurchaseOrderBuilder orderBuilder = new PurchaseOrderBuilder();
            IOrderDirector<PurchaseOrderBuilder, PurchaseOrderBuildOption> basicOrderDirector = new PurchaseOrderDirector();
           
            var PurchaseOrderBuildOptionItems = POBuilderOption();
            foreach (var PurchaseOrderBuildOptionItem in PurchaseOrderBuildOptionItems)
            {
                IOrder order = basicOrderDirector.BuildOrder(orderBuilder, PurchaseOrderBuildOptionItem);
                orders.Add(order);
            }
            return orders;
        }

        private static List<PurchaseOrderBuildOption> POBuilderOption()
        {
            Random random = new Random();
            List<PurchaseOrderBuildOption> items = new List<PurchaseOrderBuildOption>();
            for (int orderNum = 1; orderNum <= 5; orderNum++)
            {
                string orderId = Guid.NewGuid().ToString();
                PurchaseOrderBuildOption purchaseOrderBuildOption = new PurchaseOrderBuildOption()
                {
                    Id = orderId,
                    OrderStatus = orderNum==3? OrderStatus.Rejected: OrderStatus.Approved,
                    OrderNo = "ORD" + orderNum,
                    Items = new List<IOrderItem>(),
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    POType = PurchaseOrderType.Urgent,
                    TenderNo = "Tender-" + orderNum
                };
                purchaseOrderBuildOption.Items = new List<IOrderItem>();
                for (int itemNum = 1; itemNum <= 5; itemNum++)
                {
                    IOrderItem item = new OrderItem()
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        Id = orderId,
                        ItemName = "ABCItem" + itemNum,
                        Quantity = random.Next(5, 20),
                       
                        Unit = "pcs",
                        SupplierName = "Supplier" + itemNum,
                        SupplierEmail = "supplier" + itemNum + "@example.com"
                       
                    };
                    item.ReceivedQuantity = orderNum == 3 ? (int)(item.Quantity / 2) : item.Quantity;
                    item.RejectedQuantity = item.Quantity - item.ReceivedQuantity;
                    purchaseOrderBuildOption.Items.Add(item);
                }

                items.Add(purchaseOrderBuildOption);
            }
            return items;
        }
    }
}
