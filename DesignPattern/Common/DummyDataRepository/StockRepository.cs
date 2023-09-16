using Common.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DummyDataRepository
{
    //The Class is dummy stock repository class "List<Stock> stocks" this ack as dummy table
    public class StockRepository
    {
        private List<Stock> stocks = new List<Stock>();

        public void AddStock(Stock stock)
        {
            if (!stocks.Contains(stock))
            {
                stocks.Add(stock);
            }
        }

        public Stock? GetStock(string id)
        {
            return stocks.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateStock(Stock stock)
        {
            var existingStock = GetStock(stock.Id);
            if (existingStock != null)
            {
                existingStock.StockQuantity = stock.StockQuantity;
            }
        }

        public List<Stock> GetAllStocks()
        {
            return stocks;
        }
    }
}
