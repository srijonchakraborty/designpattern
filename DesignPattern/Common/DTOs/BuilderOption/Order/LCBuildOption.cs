using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.BuilderOption.Order
{
    public class LCBuildOption : OrderBuildOption
    {
        public string BankName { get; set; }
        public string BankEmail { get; set; }
    }
}
