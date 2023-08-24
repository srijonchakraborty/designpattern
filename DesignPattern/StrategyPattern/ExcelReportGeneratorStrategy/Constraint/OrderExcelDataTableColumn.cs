using Common.Constrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.ExcelReportGeneratorStrategy.Constraint
{
    public static class OrderExcelDataTableColumn
    {
        public static Dictionary<string, string> GetOrderSpcificColumns(string orderTypeName)
        {
            Dictionary<string, string> orderSpcificColumns = orderTypeName switch
            {
                OrderTypeNames.POModel => POExcelColumnNames,
                OrderTypeNames.SPOModel => SPOExcelColumnNames,
                OrderTypeNames.LCModel => LCExcelColumnNames,
                _ => new Dictionary<string, string>()
            };

            return orderSpcificColumns;
        }

        private static readonly Dictionary<string, string> LCExcelColumnNames = new Dictionary<string, string>()
        {
            {"OrderNo", "LC No." },
            {"CreateDate", "Date" },
            {"OrderStatus", "LC Status" },
            {"BankName", "BankName" },
            {"Orders", "LC Items" },
        };
        private static readonly Dictionary<string, string> POExcelColumnNames = new Dictionary<string, string>()
        {
            {"OrderNo", "PO No." },
            {"CreateDate", "Date" },
            {"OrderStatus", "PO Status" },
            {"POType", "Type" },
            {"TenderNo", "Tender No." },
            {"Orders", "PO Items" },
        };
        private static readonly Dictionary<string, string> SPOExcelColumnNames = new Dictionary<string, string>()
        {
            {"OrderNo", "SPO No." },
            {"CreateDate", "Date" },
            {"OrderStatus", "SPO Status" },
            {"InvoiceCashMemoNo", "Invoice No." },
            {"InvoiceDate", "Invoice Date" },
            {"Orders", "SPO Items" },
        };
    }
}
