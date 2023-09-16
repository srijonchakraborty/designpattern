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
        StockMemento MementoHistory { get; }
        void AddStock(Stock stock);
        void IncreaseStock(string stockId, double quantity);
        void DecreaseStock(string stockId, double quantity);
        List<Stock> GetAllStocks();
        void UndoLastTransaction();
        bool CheckStockInconsistency();
    }
}
