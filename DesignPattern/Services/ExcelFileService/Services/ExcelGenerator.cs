using Common.Command;
using ExcelFileService.Contracts;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileService.Services
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[]? GenerateExcelBytes(ExcelCommand command)
        {
            byte[]? bytes =null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                foreach (DataTable table in command.ExcelDataSet.Tables)
                {
                    var workSheet = excel.Workbook.Worksheets.Add(table.TableName);
                    workSheet.Cells.LoadFromDataTable(table, true);
                    FormatWorksheet(table, workSheet, command.HeaderStyle);
                }

                bytes = excel.GetAsByteArray();
            }
            return bytes;
        }
        private void FormatWorksheet(DataTable table, ExcelWorksheet workSheet, ExcelHeaderStyle excelHeaderStyle)
        {
            try
            {
                var numberOfColumn = table.Columns.Count;
                int colNumber = 1;
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        workSheet.Column(colNumber).Style.Numberformat.Format = "dd.MM.yyyy";
                    }
                    colNumber++;
                }
                workSheet.Cells[1, 1, 1, numberOfColumn].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[1, 1, 1, numberOfColumn].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                workSheet.Cells[1, 1, 1, numberOfColumn].Style.Font.Bold = true;
                workSheet.Cells.AutoFitColumns();

                if (excelHeaderStyle?.CustomHeight ?? false)
                {
                    workSheet.Row(1).CustomHeight = excelHeaderStyle.CustomHeight;
                    workSheet.Row(1).Height = excelHeaderStyle.Height;
                    SetCustomColumWith(workSheet, excelHeaderStyle);
                }

            }
            catch (Exception ex)
            {
                //TO DO Something with this error like loggin
            }
        }
        private static void SetCustomColumWith(ExcelWorksheet workSheet, ExcelHeaderStyle excelHeaderStyle)
        {
            if (excelHeaderStyle.ColumnWidths != null)
            {
                foreach (var columnWidth in excelHeaderStyle.ColumnWidths)
                {
                    workSheet.Column(columnWidth.Key).Width = columnWidth.Value;
                    workSheet.Cells[1, columnWidth.Key].Style.WrapText = true;
                }
            }
        }
    }
}
