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
    internal static class GenerateLC
    {
        internal static List<IOrder> GetLCItems()
        {
            List<IOrder> orders = new List<IOrder>();
            LCBuilder orderBuilder =null;
            IOrderDirector<LCBuilder, LCBuildOption> basicOrderDirector = new LCDirector();
           
            var LCBuildOptionItems = LCBuilderOption();
            foreach (var LCBuildOptionItem in LCBuildOptionItems)
            {
                orderBuilder = new LCBuilder();
                IOrder order = basicOrderDirector.BuildOrder(orderBuilder, LCBuildOptionItem);
                orders.Add(order);
            }
            return orders;
        }

        private static List<LCBuildOption> LCBuilderOption()
        {
            Random random = new Random();
            List<LCBuildOption> items = new List<LCBuildOption>();
            for (int orderNum = 1; orderNum <= 5; orderNum++)
            {
                string orderId = Guid.NewGuid().ToString();
                LCBuildOption lcBuildOption = new LCBuildOption()
                {
                    Id = orderId,
                    OrderStatus = orderNum==3? OrderStatus.Rejected: OrderStatus.Approved,
                    OrderNo = "LC" + orderNum,
                    Items = new List<IOrderItem>(),
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ClientEmail="srijon@yopmail.com",
                    BankName = "Common Wealth"+ orderNum,
                    BankEmail = $"info{orderNum}@commonwealth.au"
                };
                lcBuildOption.Items = new List<IOrderItem>();
                for (int itemNum = 1; itemNum <= 5; itemNum++)
                {
                    IOrderItem item = new OrderItem()
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        Id = orderId,
                        ItemName = "LCABCItem" + itemNum,
                        Quantity = random.Next(5, 20),
                        Price = random.Next(21, 30),
                        Unit = "pcs",
                        SupplierName = "LCSupplier" + itemNum,
                        SupplierEmail = "lcsupplier" + itemNum + "@yopmail.com"
                       
                    };
                    item.ReceivedQuantity = orderNum == 3 ? (int)(item.Quantity / 2) : item.Quantity;
                    item.RejectedQuantity = item.Quantity - item.ReceivedQuantity;
                    lcBuildOption.Items.Add(item);
                }

                items.Add(lcBuildOption);
            }
            return items;
        }
    }
}
