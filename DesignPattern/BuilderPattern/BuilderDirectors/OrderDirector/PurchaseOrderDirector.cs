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
    public class PurchaseOrderDirector : IOrderDirector<PurchaseOrderBuilder, PurchaseOrderBuildOption>
    {
        public IOrder BuildOrder(PurchaseOrderBuilder builder, PurchaseOrderBuildOption options)
        {
            IPurchaseOrder order;
            if (builder !=null && options != null)
            {
                builder.SetTenderNo(options.TenderNo);
                builder.SetPOType(options.POType);
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
                order = new PurchaseOrder();
            }
            return order;
        }
    }
}
