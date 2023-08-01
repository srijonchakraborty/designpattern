using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.BuilderOption.Order
{
    public class SpotPurchaseBuildOption : OrderBuildOption
    {
        public string InvoiceCashMemoNo { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
