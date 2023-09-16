using Common.Model.Stock;
using FacadePattern.Contract;
using FacadePattern.Implementation.StockFacade;
using ProxyPattern.Contracts.RemoteProxy.WeatherProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal static class FacadePatternImplementationWithPrototypeAndMemento
    {
        internal static void FacadePatternImplementation()
        {
            IStockManagementFacade stockFacade = new StockAdjustmentFacade();
            List<Stock> dummyStocks = GetStocks();

            foreach(var stock in dummyStocks)
            {
                stockFacade.AddNewStock(stock);
            }

            //It will update stock to 20
            stockFacade.IncreaseStock(dummyStocks[0].Id,20);

            var stockt = stockFacade.GetAllStocks().First(c => c.Id == dummyStocks[0].Id);
            Console.WriteLine($"Stock: {dummyStocks[0].Id} Qty: {stockt.StockQuantity}" );

            //THis action will not perform and stock will remail 30
            stockFacade.DecreaseStock(dummyStocks[0].Id, 30);
            Console.WriteLine($"Stock: {dummyStocks[0].Id} Qty:{stockFacade.GetAllStocks().First(c => c.Id == dummyStocks[0].Id).StockQuantity}");

            //Stock will reduced to 10
            stockFacade.DecreaseStock(dummyStocks[0].Id, 10);
            Console.WriteLine($"Stock: {dummyStocks[0].Id} Qty:{stockFacade.GetAllStocks().First(c => c.Id == dummyStocks[0].Id).StockQuantity}");

            Console.WriteLine($"Stock: History");
            Console.WriteLine($"--------------");
            foreach (var itm in stockFacade.GetAllStockTransactionHistory(dummyStocks[0].Id))
            {
                Console.WriteLine($"Stock:{itm.CurrentStockAtTheMoment.Id}, Time: {itm.CreateDate.ToString()},Qty:{itm.CurrentStockAtTheMoment.StockQuantity}");
            }
        }


        #region Stock Making Region (I can do that using builder. But this is more likely Facade pattern example so I go with naive process)
        private static List<Stock> GetStocks()
        {
            List<Stock> response = new List<Stock>();
            for (int i = 0; i < 5; i++)
            {
                Stock stock = new Stock();
                stock.Id = Guid.NewGuid().ToString();
                stock.StockQuantity = 0;
                stock.Item = GetProduct();
                response.Add(stock);
            }
            return response;
        }

        private static Product GetProduct()
        {
            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Unit = "Kg"
            };

            product.ItemName = "SJN-" + product.Id;
            return product;
        } 
        #endregion

    }
}
