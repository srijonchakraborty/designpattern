using Common.Model.Order;
using DecoratorPattern.Contracts;
using DecoratorPattern.DecoratorProcessor;
using DecoratorPattern.Decoretors.PurchaseOrderDecoretor;
using DesignPattern.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class DecoratorImplementation
    {
        internal static void DecoratorPatternImplementation()
        {
            var items = OrderDataCreator.CreateData();
            var pOItems = items.Where(c => c is PurchaseOrder)?.ToList();
            IPurchaseOrderDecorator[] decorators = PreapreDecorators();
            PurchaseOrderDecoratorProcessor orderDecoratorProcessor = new PurchaseOrderDecoratorProcessor(decorators);
            foreach (var po in pOItems)
            {
                orderDecoratorProcessor.Process((PurchaseOrder)po);
            }

        }

        private static IPurchaseOrderDecorator[] PreapreDecorators()
        {
            return new IPurchaseOrderDecorator[]
                     {
                        new TaxDecorator(3),
                        new DiscountDecorator(5),
                        new ExpeditedShippingDecorator(),
                        new EmailNotificationDecorator(),
                     };
        }
    }
}
