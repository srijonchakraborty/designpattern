using Common.Contracts.Order;
using Common.Model.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Strategy.OrderStrategy
{

    public class LCExcelDataTableStrategy : BaseOrderExcelDataTableStrategy
    {
        public LCExcelDataTableStrategy(Dictionary<string, string> orderSpecificColumns, string orderTypeName)
            : base(orderSpecificColumns, orderTypeName)
        {
            addLCColumns();
        }
        private void addLCColumns()
        {
            dataTable?.Columns?.Add(orderSpecificColumns["BankName"], typeof(string));
        }
        public override void SetData(DataTable dataTable, IOrder order)
        {

            var row = dataTable.NewRow();
            SetCommonData(row, order);
            if (order is LC)
            {
                SetCustomLCData(row, (ILC)order);
            }
            dataTable.Rows.Add(row);
        }
        private void SetCustomLCData(DataRow row, ILC order)
        {
            row[orderSpecificColumns["BankName"]] = order.BankName;
        }
    }
}
