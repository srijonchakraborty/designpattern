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

namespace DesignPattern
{
    internal static class VirtualProxyImplementation
    {
        internal static void VirtualProxyPatternImplementation()
        {
            var items = OrderDataCreator.CreateData();
            items = OrderDataCreator.CreateItemsDocumentData(items);
            var pOItems = items.OfType<PurchaseOrder>().ToList();
            foreach (var po in pOItems)
            {
                var cachedOrderItem = po.OrderItems[0];
                Console.WriteLine($"Product Name: {cachedOrderItem.ItemName}");

                foreach (var doc in cachedOrderItem.ItemDocuments)
                {
                    var mydoc = doc as Document;
                    var documentProxy = new DocumentVirtualProxyMemoryCache(() => doc, mydoc.FileId);
                    Console.WriteLine($"Document Name: {documentProxy.DocumentName}");
                    Console.WriteLine($"Document File Path: {documentProxy.FilePath}");

                    byte[] buffer = documentProxy.FileData;
                }
            }

        }
    }
}
