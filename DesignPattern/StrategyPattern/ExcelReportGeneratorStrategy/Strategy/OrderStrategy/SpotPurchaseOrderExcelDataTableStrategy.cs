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
    public class SpotPurchaseOrderExcelDataTableStrategy : BaseOrderExcelDataTableStrategy
    {
        public SpotPurchaseOrderExcelDataTableStrategy(Dictionary<string, string> orderSpecificColumns, string orderTypeName)
            : base(orderSpecificColumns, orderTypeName)
        {
            addSpotPurchaseOrderColumns();
        }
        private void addSpotPurchaseOrderColumns()
        {
            dataTable?.Columns?.Add(orderSpecificColumns["InvoiceCashMemoNo"], typeof(string));
            dataTable?.Columns?.Add(orderSpecificColumns["InvoiceDate"], typeof(DateTime));
        }
        public override void SetData(DataTable dataTable, IOrder order)
        {

            var row = dataTable.NewRow();
            SetCommonData(row, order);
            if (order is SpotPurchase)
            {
                SetCustomSpotPurchseOrderData(row, (ISpotPurchase)order);
            }
            dataTable.Rows.Add(row);
        }
        private void SetCustomSpotPurchseOrderData(DataRow row, ISpotPurchase order)
        {
            row[orderSpecificColumns["InvoiceCashMemoNo"]] = order.InvoiceCashMemoNo;
            row[orderSpecificColumns["InvoiceDate"]] = order.InvoiceDate;
        }
    }
}
