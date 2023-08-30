using Common.Contracts.Order;
using Common.Model.Document;
using Common.Model.Order;
using DesignPattern.Order;
using ProxyPattern.Implementation.VirtualProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;
using TempleteMethodPattern.Implementation.OrderProcess;

namespace DesignPattern
{
    internal static class TempleteMethodPatternImplementation
    {
        internal async static Task TempleteMethodImplementation()
        {
            var items = OrderDataCreator.CreateData();
            items = OrderDataCreator.CreateItemsDocumentData(items);
            var pOItems = items.OfType<PurchaseOrder>().ToList();
            var spOItems = items.OfType<SpotPurchase>().ToList();
            var lcItems = items.OfType<LC>().ToList();

            AbstractOrderProcessor processorPO = new PurchaseOrderProcessor();
            IOrder purchaseOrder = pOItems[0];
            await processorPO.ProcessOrder(purchaseOrder);

            AbstractOrderProcessor processorSPO = new SpotPurchaseProcessor();
            IOrder spotpurchaseOrder = spOItems[0];
            await processorSPO.ProcessOrder(spotpurchaseOrder);

            AbstractOrderProcessor processorLc = new LCOrderProcessor();
            IOrder lcOrder = lcItems[0];
            await processorLc.ProcessOrder(lcOrder);

        }
    }
}
