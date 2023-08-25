using Common.Model.Order;
using DecoratorPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decoretors.PurchaseOrderDecoretor
{
    public class DiscountDecorator : IPurchaseOrderDecorator
    {
        private readonly double discountInPercent;

        public DiscountDecorator(double discountInPercent)
        {
            this.discountInPercent = discountInPercent;
        }

        public void Apply(PurchaseOrder order)
        {
            //Here We can add more complex log to calculate discount
            order.DiscountAmount = order.TotalAmount * (discountInPercent / 100);
        }
    }
}
