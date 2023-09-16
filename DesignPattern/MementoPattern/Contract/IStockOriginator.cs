using Common.DummyDataRepository;
using Common.Model.Stock;
using MementoPattern.Implementation.StockMemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Contract
{
    public interface IStockOriginator
    {
        StockRepository Repository { get; }
        StockMemento MementoHistory { get; }
        void AddStock(Stock stock);
        void IncreaseStock(string stockId, int quantity);
        void DecreaseStock(string stockId, int quantity);
        List<Stock> GetAllStocks();
        void UndoLastTransaction();
        void SaveMemento();
        bool CheckStockInconsistency();
    }
}
