using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;

namespace TempleteMethodPattern.Implementation.OrderProcess
{
    public class PurchaseOrderProcessor : AbstractOrderProcessor
    {
        protected override List<string> SendEmail(IOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }
        protected async Task <List<string>> SendPhoneAlert(IOrder purchaseOrder)
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
