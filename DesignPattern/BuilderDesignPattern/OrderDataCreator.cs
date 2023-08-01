using BuilderPattern.BuilderDirectors.OrderDirector;
using BuilderPattern.BuilderInterface;
using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPattern.BuilderConcrete.OrderBuilder;

namespace DesignPattern
{
    public static class OrderDataCreator
    {
        public static void CreateData()
        {
            List<IOrder> orders = new List<IOrder>();
            PurchaseOrderBuilder orderBuilder = new PurchaseOrderBuilder();
            IOrderDirector<PurchaseOrderBuilder, PurchaseOrderBuildOption> basicOrderDirector = new PurchaseOrderDirector();
            IOrder order = basicOrderDirector.BuildOrder(orderBuilder,new PurchaseOrderBuildOption
            {
                Id = "123",
                OrderStatus = OrderStatus.Pending,
                OrderNo = "ORD123",
                Items = new List<IOrderItem>
                {
                    // Add OrderItems here
                },
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                POType=PurchaseOrderType.Urgent,
                TenderNo="Tender-001"
            });
            orders.Add(order);

            SpotPurchaseBuilder spotorderBuilder = new SpotPurchaseBuilder();
            IOrderDirector<SpotPurchaseBuilder, SpotPurchaseBuildOption> spotDirector = new SpotPurchaseOrderDirector();
            IOrder spotorder = spotDirector.BuildOrder(spotorderBuilder, new SpotPurchaseBuildOption
            {
                Id = "124",
                OrderStatus = OrderStatus.Approved,
                OrderNo = "ORD124",
                Items = new List<IOrderItem>
                {
                    // Add OrderItems here
                },
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                InvoiceCashMemoNo = "INV-001",
                InvoiceDate = DateTime.Now.AddDays(-10)
            });
            orders.Add(spotorder);
            Console.WriteLine("Spot Object"+ spotorder?.ToString());

            LCBuilder lcBuilder = new LCBuilder();
            IOrderDirector<LCBuilder, LCBuildOption> lCDirector = new LCDirector();
            IOrder lc = lCDirector.BuildOrder(lcBuilder, new LCBuildOption
            {
                Id = "125",
                OrderStatus = OrderStatus.Pending,
                OrderNo = "ORD125",
                Items = new List<IOrderItem>
                {
                    // Add OrderItems here
                },
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                BankName = "Common Wealth",
                BankEmail = "info@commonwealth.au"
            });
            orders.Add(lc);
            Console.WriteLine("LC Object" + lc?.ToString());
        }
    }
}
