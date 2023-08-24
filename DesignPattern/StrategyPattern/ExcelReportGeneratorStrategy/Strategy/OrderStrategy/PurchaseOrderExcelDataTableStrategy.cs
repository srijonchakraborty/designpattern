using Common.Contracts.Order;
using Common.Extentions;
using Common.Model.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Strategy.OrderStrategy
{
    public class PurchaseOrderExcelDataTableStrategy : BaseOrderExcelDataTableStrategy
    {
        public PurchaseOrderExcelDataTableStrategy(Dictionary<string, string> orderSpecificColumns, string orderTypeName)
            : base(orderSpecificColumns, orderTypeName)
        {
            addPurchaseOrderColumns();
        }
        private void addPurchaseOrderColumns()
        {
            dataTable?.Columns?.Add(orderSpecificColumns["POType"], typeof(string));
            dataTable?.Columns?.Add(orderSpecificColumns["TenderNo"], typeof(string));
        }
        public override void SetData(DataTable dataTable, IOrder order)
        {

            var row = dataTable.NewRow();
            SetCommonData(row, order);
            if (order is PurchaseOrder)
            {
                SetCustomPurchseOrderData(row, (IPurchaseOrder)order);
            }
            dataTable.Rows.Add(row);
        }
        private void SetCustomPurchseOrderData(DataRow row, IPurchaseOrder order)
        {
            row[orderSpecificColumns["POType"]] = order.POType.ToString();
            row[orderSpecificColumns["TenderNo"]] = order.TenderNo.ToString();
        }
    }
}
