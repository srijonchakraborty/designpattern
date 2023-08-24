using Common.Contracts.Order;
using Common.Extentions;
using StrategyPattern.ExcelReportGeneratorStrategy.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Strategy.OrderStrategy
{
    public abstract class BaseOrderExcelDataTableStrategy : IOrderExcelDataTableStrategy
    {
        #region orderTypeName: string
        private readonly string orderTypeName;
        public string OrderTypeName
        {
            get
            {
                return orderTypeName;
            }
        }
        #endregion

        protected DataTable dataTable;
        protected readonly Dictionary<string, string> orderSpecificColumns;
        protected BaseOrderExcelDataTableStrategy(Dictionary<string, string> orderSpecificColumns, string orderTypeName)
        {
            dataTable = new DataTable(orderTypeName);
            this.orderSpecificColumns = orderSpecificColumns;
            this.orderTypeName = orderTypeName;
            AddBaseColumns();
        }
        public abstract void SetData(DataTable dataTable, IOrder order);
        public DataTable GetDataTable()
        {
            return dataTable;
        }
        protected void SetCommonData(DataRow row, IOrder order)
        {
            row[orderSpecificColumns["OrderNo"]] = order.OrderNo;
            row[orderSpecificColumns["CreateDate"]] = order.CreateDate;
            row[orderSpecificColumns["OrderStatus"]] = order.OrderStatus.ToString();
            row[orderSpecificColumns["Orders"]] = order.GetOrderItemDetails();
        }
        private void AddBaseColumns()
        {
            dataTable.Columns.Add(orderSpecificColumns["OrderNo"], typeof(string));
            dataTable.Columns.Add(orderSpecificColumns["CreateDate"], typeof(DateTime));
            dataTable.Columns.Add(orderSpecificColumns["OrderStatus"], typeof(string));
            dataTable.Columns.Add(orderSpecificColumns["Orders"], typeof(string));
        }
    }
}
