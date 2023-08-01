using BuilderPattern.BuilderConcrete.OrderBuilder;
using BuilderPattern.BuilderInterface;
using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using Common.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderDirectors.OrderDirector
{
    public class SpotPurchaseOrderDirector : IOrderDirector<SpotPurchaseBuilder, SpotPurchaseBuildOption>
    {
        public IOrder BuildOrder(SpotPurchaseBuilder builder, SpotPurchaseBuildOption options)
        {
            ISpotPurchase order;
            if (builder !=null && options != null)
            {
                builder.SetInvoiceCashMemoNo(options.InvoiceCashMemoNo);
                builder.SetInvoiceDate(options.InvoiceDate);
                order = builder
                        .SetId(options.Id)
                        .SetOrderStatus(options.OrderStatus)
                        .SetOrderNo(options.OrderNo)
                        .SetOrders(options.Items)
                        .SetCreateDate(options.CreateDate)
                        .SetModifiedDate(options.ModifiedDate)
                        .Build();
            }
            else
            {
                order = new SpotPurchase();
            }
            return order;
        }
    }
}
