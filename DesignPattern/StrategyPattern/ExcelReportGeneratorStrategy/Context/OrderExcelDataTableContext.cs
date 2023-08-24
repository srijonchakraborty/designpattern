using Common.Contracts.Order;
using StrategyPattern.ExcelReportGeneratorStrategy.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Context
{
    public class OrderExcelDataTableContext
    {
        private readonly IOrderExcelDataTableStrategy _strategy;
        public OrderExcelDataTableContext(IOrderExcelDataTableStrategy strategy)
        {
            _strategy = strategy;
        }
        public DataTable GetDataTable()
        {
            return _strategy.GetDataTable();
        }
        public void SetData(DataTable dataTable, List<IOrder> orders)
        {
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    _strategy.SetData(dataTable, order);
                }
            }
        }
    }
}
