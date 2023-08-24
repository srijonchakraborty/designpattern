using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Contracts
{
    public interface IOrderExcelDataTableStrategy
    {
        string OrderTypeName { get; }
        DataTable GetDataTable();
        void SetData(DataTable dataTable, IOrder order);
    }
}
