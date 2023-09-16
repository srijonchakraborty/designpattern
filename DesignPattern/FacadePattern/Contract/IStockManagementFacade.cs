using Common.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Contract
{
    public interface IStockManagementFacade
    {
        void AddNewStock(Stock stock);
        void IncreaseStock(string stockId, double quantity);
        void DecreaseStock(string stockId, double quantity);
        List<Stock> GetAllStocks();
        List<StockTransactionHistory> GetAllStockTransactionHistory(string stockid);
    }
}
