using Common.Model.Order;
using DecoratorPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decoretors.PurchaseOrderDecoretor
{
    public class ExpeditedShippingDecorator : IPurchaseOrderDecorator
    {
        public void Apply(PurchaseOrder order)
        {
            //This might come from db or other service
            //It is also possible that shipmming fee might have complex logic for each item depending on order => order.OrderItems.FirstOrDefault(x=>x.SupplierName)
            //So, we can calculate complex shipping fee here
            double ShippingFee = 20.0;
            order.ShippingFee = ShippingFee;
        }
    }
}
