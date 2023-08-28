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
    internal static class GenerateSpotPurchase
    {
        internal static List<IOrder> GetSPOItems()
        {
            List<IOrder> orders = new List<IOrder>();
            SpotPurchaseBuilder orderBuilder = null;
            IOrderDirector<SpotPurchaseBuilder, SpotPurchaseBuildOption> basicOrderDirector = new SpotPurchaseOrderDirector();
           
            var SpotPurchaseBuildOptionItems = SPOBuilderOption();
            foreach (var SpotPurchaseBuildOptionItem in SpotPurchaseBuildOptionItems)
            {
                orderBuilder = new SpotPurchaseBuilder();
                IOrder order = basicOrderDirector.BuildOrder(orderBuilder, SpotPurchaseBuildOptionItem);
                orders.Add(order);
            }
            return orders;
        }

        private static List<SpotPurchaseBuildOption> SPOBuilderOption()
        {
            Random random = new Random();
            List<SpotPurchaseBuildOption> items = new List<SpotPurchaseBuildOption>();
            for (int orderNum = 1; orderNum <= 5; orderNum++)
            {
                string orderId = Guid.NewGuid().ToString();
                SpotPurchaseBuildOption SpotPurchaseBuildOption = new SpotPurchaseBuildOption()
                {
                    Id = orderId,
                    OrderStatus = orderNum==3? OrderStatus.Rejected: OrderStatus.Approved,
                    OrderNo = "SORD" + orderNum,
                    Items = new List<IOrderItem>(),
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ClientEmail = "srijon@yopmail.com",
                    InvoiceCashMemoNo ="INV-"+ orderNum,
                    InvoiceDate= DateTime.Now.AddDays(orderNum*-1),
                };
                SpotPurchaseBuildOption.Items = new List<IOrderItem>();
                for (int itemNum = 1; itemNum <= 5; itemNum++)
                {
                    IOrderItem item = new OrderItem()
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        Id = orderId,
                        ItemName = "SPOABCItem" + itemNum,
                        Quantity = random.Next(5, 20),
                        Price = random.Next(21, 30),
                        Unit = "pcs",
                        SupplierName = "SPOSupplier" + itemNum,
                        SupplierEmail = "sposupplier" + itemNum + "@yopmail.com"

                    };
                    item.ReceivedQuantity = orderNum == 3 ? (int)(item.Quantity / 2) : item.Quantity;
                    item.RejectedQuantity = item.Quantity - item.ReceivedQuantity;
                    SpotPurchaseBuildOption.Items.Add(item);
                }

                items.Add(SpotPurchaseBuildOption);
            }
            return items;
        }
    }
}
