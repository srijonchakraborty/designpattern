using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.BuilderOption.Order
{
    public class PurchaseOrderBuildOption : OrderBuildOption
    {
        public PurchaseOrderType POType { get; set; }
        public string TenderNo { get; set; }
    }
}
