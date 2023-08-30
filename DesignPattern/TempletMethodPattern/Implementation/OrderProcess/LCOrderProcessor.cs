using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;

namespace TempleteMethodPattern.Implementation.OrderProcess
{
    public class LCOrderProcessor : AbstractOrderProcessor
    {
        protected async override Task<List<string>> SendEmailAsync(IOrder purchaseOrder)
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
