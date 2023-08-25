using Common.Model.Order;
using DecoratorPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorProcessor
{
   
    public class PurchaseOrderDecoratorProcessor
    {
        private readonly List<IPurchaseOrderDecorator> _decorators;

        public PurchaseOrderDecoratorProcessor(params IPurchaseOrderDecorator[] decorators)
        {
            _decorators = new List<IPurchaseOrderDecorator>(decorators);
        }

        public void Process(PurchaseOrder order)
        {
            foreach (var decorator in _decorators)
            {
                decorator.Apply(order);
            }
        }
    }
}
