using Common.DummyDataRepository;
using Common.Model.Stock;
using MementoPattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Implementation.StockMemento
{
    public class StockOriginator : IStockOriginator
    {
        private readonly List<Stock> stocks = new List<Stock>();
        public StockOriginator()
        {
            repository = new StockRepository();//this will be injected and set here
            mementoHistory = new StockMemento();
        }

        private readonly StockRepository repository;
        public StockRepository Repository
        {
            get { return repository; }
        }
        private readonly StockMemento mementoHistory;
        public StockMemento MementoHistory
        {
            get { return mementoHistory; }
        }

        public void AddStock(Stock stock)
        {
            repository.AddStock(stock);
            stocks.Add(stock);
            SaveMemento();
            Console.WriteLine($"Added new Stock: {stock.Item?.ItemName}");
        }

       

        public void DecreaseStock(string stockId, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetAllStocks()
        {
            return repository.GetAllStocks();
        }

        public void IncreaseStock(string stockId, int quantity)
        {
            var stock = repository.GetStock(stockId);
            if (stock == null)
            {
                Console.WriteLine($"Error: Stock '{stockId}' not found.");
                return;
            }

            stock.StockQuantity += quantity;
            repository.UpdateStock(stock);
            SaveMemento();
            Console.WriteLine($"Increased stock of {stockId} by {quantity} units.");
        }
        public bool CheckStockInconsistency()
        {
            return false;

        }
        public void SaveMemento()
        {
            //need prototype pattern to clone object of stock and set StockTransactionHistory
            //Build new StockTransactionHistory
            mementoHistory.SetStockTransactionHistory(new StockTransactionHistory());
           
        }

        public void UndoLastTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
