using Common.Command;
using Common.Constrains;
using Common.Contracts.Order;
using Common.Model.Order;
using ExcelFileService.Contracts;
using ExcelFileService.Services;
using StrategyPattern.ExcelReportGeneratorStrategy.Constraint;
using StrategyPattern.ExcelReportGeneratorStrategy.Context;
using StrategyPattern.ExcelReportGeneratorStrategy.Strategy.OrderStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Order
{
    internal class OrderReportStrategyImplementation
    {
        private readonly string folderPath;
        private readonly IExcelGenerator excelGenerator;
        
        public OrderReportStrategyImplementation(string folderPath)
        {
            this.folderPath = folderPath;
            excelGenerator = new ExcelGenerator();
        }
        public void GenerateAllInOneReport()
        {
            var dataSet = new DataSet();
            var items = OrderDataCreator.CreateData();
            var pOItems = items.Where(c => c is PurchaseOrder)?.ToList();
            PreparePurchaseOrderDataSet(dataSet,pOItems);

            var spOItems = items.Where(c => c is SpotPurchase)?.ToList();
            PrepareSpotPurchaseDataSet(dataSet, spOItems);

            var lcItems = items.Where(c => c is LC)?.ToList();
            PrepareLCDataSet(dataSet, lcItems);
            
            var excelGenerationCommand = new ExcelCommand
            {
                ExcelDataSet = dataSet,
            };

            byte[]? byteArray = excelGenerator.GenerateExcelBytes(excelGenerationCommand);
            SaveReport(byteArray, "Order_All_In_One");
        }
        public void GenerateReport()
        {
            var items= OrderDataCreator.CreateData();
            var pOItems = items.Where(c => c is PurchaseOrder)?.ToList();
            GeneratePurchaseOrderReport(pOItems);

            var spOItems = items.Where(c => c is SpotPurchase)?.ToList();
            GenerateSpotPurchaseReport(spOItems);

            var lcItems = items.Where(c => c is LC)?.ToList();
            GenerateLCReport(lcItems);
        }
        private void GeneratePurchaseOrderReport(List<IOrder> items)
        {
            var dataSet = new DataSet();
            PreparePurchaseOrderDataSet(dataSet, items);
            var excelGenerationCommand = new ExcelCommand
            {
                ExcelDataSet = dataSet,
            };

            byte[]? byteArray =excelGenerator.GenerateExcelBytes(excelGenerationCommand);
            SaveReport(byteArray, "PO");
        }
        private void PreparePurchaseOrderDataSet(DataSet dataSet,List<IOrder> items)
        {
            var ordercolumns = OrderExcelDataTableColumn.GetOrderSpcificColumns(OrderTypeNames.POModel);
            OrderExcelDataTableContext reportContext = new OrderExcelDataTableContext(new PurchaseOrderExcelDataTableStrategy(ordercolumns, OrderTypeNames.POModel));
            DataTable dataTable = reportContext.GetDataTable();
            reportContext.SetData(dataTable, items);
            dataSet.Tables.Add(dataTable);
        }
        private void GenerateSpotPurchaseReport(List<IOrder> items)
        {
            var dataSet = new DataSet();
            PrepareSpotPurchaseDataSet(dataSet, items);
            var excelGenerationCommand = new ExcelCommand
            {
                ExcelDataSet = dataSet,
            };

            byte[]? byteArray = excelGenerator.GenerateExcelBytes(excelGenerationCommand);
            SaveReport(byteArray, "SPO");
        }
        private void PrepareSpotPurchaseDataSet(DataSet dataSet, List<IOrder> items)
        {
            var ordercolumns = OrderExcelDataTableColumn.GetOrderSpcificColumns(OrderTypeNames.SPOModel);
            OrderExcelDataTableContext reportContext = new OrderExcelDataTableContext(new SpotPurchaseOrderExcelDataTableStrategy(ordercolumns, OrderTypeNames.SPOModel));
            DataTable dataTable = reportContext.GetDataTable();
            reportContext.SetData(dataTable, items);
            dataSet.Tables.Add(dataTable);
        }
        private void GenerateLCReport(List<IOrder> items)
        {
            var dataSet = new DataSet();
            PrepareLCDataSet(dataSet, items);

            var excelGenerationCommand = new ExcelCommand
            {
                ExcelDataSet = dataSet,
            };

            byte[]? byteArray = excelGenerator.GenerateExcelBytes(excelGenerationCommand);
            SaveReport(byteArray, "LC");
        }
        private void PrepareLCDataSet(DataSet dataSet, List<IOrder> items)
        {
            var ordercolumns = OrderExcelDataTableColumn.GetOrderSpcificColumns(OrderTypeNames.LCModel);
            OrderExcelDataTableContext reportContext = new OrderExcelDataTableContext(new LCExcelDataTableStrategy(ordercolumns, OrderTypeNames.LCModel));
            DataTable dataTable = reportContext.GetDataTable();
            reportContext.SetData(dataTable, items);
            dataSet.Tables.Add(dataTable);
        }
        private void SaveReport(byte[]? byteArray,string filePrefix)
        {
            try
            {
                if (byteArray != null)
                {
                    string filename = $"{filePrefix}_{Guid.NewGuid().ToString()}.xlsx";
                    string fullPath = Path.Combine(folderPath, filename);
                    using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        fileStream.Write(byteArray, 0, byteArray.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
