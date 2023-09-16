using Common.DummyDataRepository;
using Common.Model.Stock;
using MementoPattern.Contract;
using PrototypePattern.Contract;
using PrototypePattern.Implementation.Stock;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Implementation.StockMemento
{
    public class StockOriginator : IStockOriginator
    {
        private readonly List<Stock> stocks = new List<Stock>();
        private readonly IPrototype<Stock> tstocks = new StockPrototype();
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
            SaveMemento(stock);
            Console.WriteLine($"Added new Stock: {stock.Item?.ItemName}");
        }

        public void DecreaseStock(string stockId, int quantity)
        {
            var stock = repository.GetStock(stockId);
            if (stock == null)
            {
                Console.WriteLine($"Error: Stock '{stockId}' not found.");
                return;
            }

            if (stock.StockQuantity < quantity)
            {
                Console.WriteLine($"Error: Insufficient stock of {stock?.Item?.ItemName??""} for the requested quantity.");
                return;
            }

            stock.StockQuantity -= quantity;
            repository.UpdateStock(stock);
            SaveMemento(stock);
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
            SaveMemento(stock);
        }
        public bool CheckStockInconsistency()
        {
            if (mementoHistory != null && mementoHistory.StockTransactionHistories != null)
            {
               return CheckStock(mementoHistory.StockTransactionHistories);
            }   
            return false;

        }

        private bool CheckStock(IReadOnlyList<StockTransactionHistory> stockTransactionHistories)
        {
            foreach (var history in stockTransactionHistories)
            {
                if (history.CurrentStockAtTheMoment.StockQuantity < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveMemento(Stock stock)
        {
            StockTransactionHistory history= PrepareStockTransactionHistory(stock);
            mementoHistory.SetStockTransactionHistory(history);
        }

        private StockTransactionHistory PrepareStockTransactionHistory(Stock stock)
        {
            StockTransactionHistory result= new StockTransactionHistory();
            result.CurrentStockAtTheMoment = tstocks?.DeepUsingJsonClone(stock) ?? new Stock();
            result.CreateDate=DateTime.Now;
            result.CreateDate = DateTime.Now;

            return result;
        }

        public void UndoLastTransaction()
        {
            if (mementoHistory.StockTransactionHistories.Count > 1)
            {
                var restorePoint=mementoHistory.StockTransactionHistories[mementoHistory.StockTransactionHistories.Count - 2];
                var stock = repository.GetStock(restorePoint.CurrentStockAtTheMoment.Id);
                stock.StockQuantity = restorePoint.CurrentStockAtTheMoment.StockQuantity;
                repository.UpdateStock(stock);
            }
            mementoHistory.RemoveLastTransactionHistory();
        }
    }
}
