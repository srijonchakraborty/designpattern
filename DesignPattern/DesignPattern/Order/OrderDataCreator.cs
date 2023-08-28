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
using OfficeOpenXml.Style;
using Common.Model.Order;
using Common.Model.Document;

namespace DesignPattern.Order
{
    public static class OrderDataCreator
    {
        public static List<IOrder> CreateData()
        {
            List<IOrder> orders = new List<IOrder>();
            orders.AddRange(GeneratePurchaseOrder.GetPOItems());
            orders.AddRange(GenerateSpotPurchase.GetSPOItems());
            orders.AddRange(GenerateLC.GetLCItems());
            return orders;
        }
        public static List<IOrder> CreateItemsDocumentData(List<IOrder> orders)
        {
            foreach (var order in orders)
            {
                CreateItemDocumentData(order);
            }
            return orders;
        }
        private static void CreateItemDocumentData(IOrder order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                PreapareItemDocument(orderItem);
            }
        }

        private static void PreapareItemDocument(IOrderItem orderItem)
        {
            orderItem.ItemDocuments = new List<Common.Contracts.Document.IDocument>();
            for(int i = 0; i < 3; i++)
            {
                var file = new Document()
                {
                    FileId = Guid.NewGuid().ToString(),
                    FilePath = "D:\\FileExcel\\LC_0b1d9b32-2950-48ea-9f8d-082fa8190fd6.xlsx"
                };
                file.DocumentName = $"Doc-{file.FileId}";
                orderItem.ItemDocuments.Add(file);
            }
        }
    }
}
