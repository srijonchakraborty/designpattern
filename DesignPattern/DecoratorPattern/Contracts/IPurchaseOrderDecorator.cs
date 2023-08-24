using Common.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Contracts
{
    public interface IPurchaseOrderDecorator
    {
       void Apply(PurchaseOrder order);
    }
}
