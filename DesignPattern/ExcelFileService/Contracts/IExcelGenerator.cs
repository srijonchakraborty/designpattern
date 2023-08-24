using Common.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileService.Contracts
{
    public interface IExcelGenerator
    {
        byte[]? GenerateExcelBytes(ExcelCommand command);
    }
}
