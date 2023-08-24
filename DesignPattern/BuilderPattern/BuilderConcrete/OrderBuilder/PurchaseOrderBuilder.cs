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
    public class PurchaseOrderBuilder : OrderBuilder<IPurchaseOrder>
    {
        protected override IPurchaseOrder CreateInstance() => new PurchaseOrder();
        public OrderBuilder<IPurchaseOrder> SetTenderNo(string TenderNo)
        {
            target.TenderNo = TenderNo;
            return this;
        }
        public OrderBuilder<IPurchaseOrder> SetPOType(PurchaseOrderType purchaseOrderType)
        {
            target.POType = purchaseOrderType;
            return this;
        }
       
    }
}
