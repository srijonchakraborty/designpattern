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
            _repository=new StockRepository();//this will be injected and set here
            _mementoHistory =new StockMemento();
        }

        private readonly StockRepository _repository;
        public StockRepository Repository
        {
            get { return _repository; }
        }
        private readonly StockMemento _mementoHistory;
        public StockMemento MementoHistory
        {
            get { return _mementoHistory; }
        }

        public void AddStock(Stock stock)
        {
            _repository.AddStock(stock);
            stocks.Add(stock);
            SaveMemento();
            Console.WriteLine($"Added new Stock: {stock.Item?.ItemName}");
        }

        public bool CheckStockInconsistency()
        {
            throw new NotImplementedException();
        }

        public void DecreaseStock(string stockId, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetAllStocks()
        {
            throw new NotImplementedException();
        }

        public void IncreaseStock(string stockId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void SaveMemento()
        {
            //new StockMemento(products)
            //_mementoHistory.SetStockTransactionHistory();
            ////currentIndex = mementoHistory.Count - 1;
        }

        public void UndoLastTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
