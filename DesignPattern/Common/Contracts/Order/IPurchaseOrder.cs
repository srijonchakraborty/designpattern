using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Order
{
    public interface IPurchaseOrder : IOrder
    {
        PurchaseOrderType POType { get; set; }
        string TenderNo { get; set; }
    }
}
