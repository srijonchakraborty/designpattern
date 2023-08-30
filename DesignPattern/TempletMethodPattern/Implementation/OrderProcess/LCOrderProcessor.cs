using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempletMethodPattern.Contracts.OrderProcess;

namespace TempletMethodPattern.Implementation.OrderProcess
{
    public class LCOrderProcessor : AbstractOrderProcessor
    {
        protected override List<string> SendEmail(IOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }
        protected override List<string> AdditioanlValidation(IOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

        protected override List<string> CheckItemDocuments(IOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

        protected override List<string> CheckOrderStatus(IOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }
    }
}
