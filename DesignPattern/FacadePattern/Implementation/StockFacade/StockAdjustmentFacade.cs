using Common.Model.Stock;
using FacadePattern.Contract;
using MementoPattern.Contract;
using MementoPattern.Implementation.StockMemento;

namespace FacadePattern.Implementation.StockFacade
{
    public class StockAdjustmentFacade : IStockManagementFacade
    {
        private readonly IStockOriginator stockOriginator;

        public StockAdjustmentFacade()
        {
            stockOriginator = new StockOriginator();
        }
        public void AddNewStock(Stock stock)
        {
            stockOriginator.AddStock(stock);
        }
        public void IncreaseStock(string stockId, double quantity)
        {
            stockOriginator.IncreaseStock(stockId, quantity);
            if(CheckStockInconsistency())
            {
                stockOriginator.UndoLastTransaction();
            }
            //Here we can add more complexity and more add more dependent modules to calculate/update Stock
        }
        public void DecreaseStock(string stockId, double quantity)
        {
            stockOriginator.DecreaseStock(stockId, quantity);
            if (CheckStockInconsistency())
            {
                stockOriginator.UndoLastTransaction();
            }
            //Here we can add more complexity and more add more dependent modules to calculate/update Stock
        }
        public List<Stock> GetAllStocks()
        {
            return stockOriginator.GetAllStocks();
        }
        private bool CheckStockInconsistency()
        {
            return stockOriginator.CheckStockInconsistency();
        }

        public List<StockTransactionHistory> GetAllStockTransactionHistory(string stockid)
        {
            return stockOriginator?.MementoHistory?.StockTransactionHistories?.Where(c => (c.CurrentStockAtTheMoment?.Id ?? "") == stockid)?.ToList()
                   ?? new List<StockTransactionHistory>();
        }
    }
}
