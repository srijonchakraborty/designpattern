using Common.Model.Order;
using DecoratorPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decoretors.PurchaseOrderDecoretor
{

    public class TaxDecorator : IPurchaseOrderDecorator
    {
        private readonly double _taxRate;

        public TaxDecorator(double taxRate)
        {
            _taxRate = taxRate;
        }

        public void Apply(PurchaseOrder order)
        {
            double tax = order.TotalAmount * (_taxRate / 100);
            order.TaxAmount = tax;
        }
    }
}
