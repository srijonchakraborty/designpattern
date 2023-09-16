using Common.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Contract
{
    public interface IStockMemento
    {
        List<StockTransactionHistory> StockTransactionHistories { get; }
        void SetStockTransactionHistory(StockTransactionHistory history);
        void RemoveStockTransactionHistory(List<StockTransactionHistory> histories);
    }
}
