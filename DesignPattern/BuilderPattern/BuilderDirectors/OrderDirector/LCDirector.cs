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
    public class LCDirector : IOrderDirector<LCBuilder, LCBuildOption>
    {
        public IOrder BuildOrder(LCBuilder builder, LCBuildOption options)
        {
            ILC order;
            if (builder !=null && options != null)
            {
                builder.SetBankName(options.BankName);
                builder.SetBankEmail(options.BankEmail);
                order = builder
                        .SetId(options.Id)
                        .SetOrderStatus(options.OrderStatus)
                        .SetOrderNo(options.OrderNo)
                        .SetOrders(options.Items)
                        .SetCreateDate(options.CreateDate)
                        .SetModifiedDate(options.ModifiedDate)
                        .SetClientEmail(options.ClientEmail)
                        .Build();
            }
            else
            {
                order = new LC();
            }
            return order;
        }
    }
}
