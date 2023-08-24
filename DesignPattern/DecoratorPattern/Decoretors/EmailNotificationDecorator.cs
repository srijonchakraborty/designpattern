using Common.Model.Order;
using DecoratorPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decoretors
{
   
    public class EmailNotificationDecorator : IPurchaseOrderDecorator
    {
        public void Apply(PurchaseOrder order)
        {
            //We will send email using Email Notification Builder and Using Email send Service
        }
    }
}
