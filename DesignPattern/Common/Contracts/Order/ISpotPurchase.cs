using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Order
{
    public interface ISpotPurchase : IOrder
    {
        string InvoiceCashMemoNo { get; set; }
        DateTime InvoiceDate { get; set; }
    }
}
