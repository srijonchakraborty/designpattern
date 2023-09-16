using Common.Model.Stock;
using MementoPattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Implementation.StockMemento
{
    public class StockMemento : IStockMemento
    {
        public StockMemento()
        {
            _stockTransactionHistories=new List<StockTransactionHistory>();
        }
       
        private readonly List<StockTransactionHistory> _stockTransactionHistories;
        public IReadOnlyList<StockTransactionHistory> StockTransactionHistories
        {
            get { return _stockTransactionHistories; }
        }

        public void SetStockTransactionHistory(StockTransactionHistory history)
        {
            _stockTransactionHistories.Add(history);
        }

        public void RemoveStockTransactionHistory(List<StockTransactionHistory> histories)
        {
            if (histories != null)
            {
                foreach (var history in histories)
                {
                    RemoveHistory(history);
                }
            }
        }
        private void RemoveHistory(StockTransactionHistory history)
        {
            if (_stockTransactionHistories.Contains(history))
            {
                _stockTransactionHistories.Remove(history);
            }
        }
    }
}
