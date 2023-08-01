using Common.Contracts.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPattern.BuilderInterface;
using Common.Model.Order;

namespace BuilderPattern.BuilderConcrete.OrderBuilder
{
    public class SpotPurchaseBuilder : OrderBuilder<ISpotPurchase>
    {
        protected override ISpotPurchase CreateInstance() => new SpotPurchase();
        public OrderBuilder<ISpotPurchase>  SetInvoiceCashMemoNo(string InvoiceCashMemoNo)
        {
            target.InvoiceCashMemoNo = InvoiceCashMemoNo;
            return this;
        }
        public OrderBuilder<ISpotPurchase> SetInvoiceDate(DateTime InvoiceDate)
        {
            target.InvoiceDate = InvoiceDate;
            return this;
        }
    }
}
