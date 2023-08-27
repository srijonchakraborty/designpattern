using Common.Contracts.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyPattern.Implementation.ProtectionProxy.OrderProtection;
using ProxyPattern.Contracts.ProtectionProxy.OrderProtection;
using Common.Model.Order;
using DesignPattern.Order;
using Common.Constrains;
using OfficeOpenXml.Style;

namespace DesignPattern
{
    internal class ProtectionProxyImplementation
    {
        internal static void ProtectionProxyPatternImplementation()
        {
            var items = OrderDataCreator.CreateData();
            var pOItems = items.OfType<PurchaseOrder>().ToList();
            int randomIndex =0;
            foreach (var itm in pOItems.ToList())
            {
                IOrderStatusProxy<IOrder> orderStatusProxy = new PurchaseOrderStatusProtectionProxy<IOrder>(AllRoles[randomIndex], itm);
                orderStatusProxy.UpdateStatus(OrderStatus.Cancelled);
                randomIndex++;
            }
            randomIndex = 0;
            var spOItems = items.OfType<SpotPurchase>().ToList();
            foreach (var itm in spOItems)
            {
                IOrderStatusProxy<IOrder> orderStatusProxy = new SpotPurchaseOrderStatusProtectionProxy<IOrder>(AllRoles[randomIndex], itm);
                orderStatusProxy.UpdateStatus(OrderStatus.Rejected);
                randomIndex++;
            }
        }

        public static string[] AllRoles
        {
            get
            {
                return new string[]
                {
                  Roles.Admin,
                  Roles.FinancialManger,
                  Roles.TechManager,
                  Roles.Executive,
                  Roles.User
                };
            }
        }
    }
}
