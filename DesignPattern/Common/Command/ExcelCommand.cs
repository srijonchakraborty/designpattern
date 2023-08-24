using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Command
{
    public class ExcelCommand
    {
        public string ExcelName { get; set; }
        public DataSet ExcelDataSet { get; set; }
        public ExcelHeaderStyle HeaderStyle { get; set; }
    }
    public class ExcelHeaderStyle
    {
        public ExcelHeaderStyle()
        {
            ColumnWidths = new Dictionary<int, double>();
        }
        public bool CustomHeight { get; set; }
        public double Height { get; set; }
        public Dictionary<int, double> ColumnWidths { get; set; }
    }
}
