using Common.Constrains;
using Common.Contracts.Order;
using Common;
using ProxyPattern.Contracts.ProtectionProxy.OrderProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyPattern.Constrains;

namespace ProxyPattern.Implementation.ProtectionProxy.OrderProtection
{
    public class SpotPurchaseOrderStatusProtectionProxy<T> : IOrderStatusProtectionProxy<T> where T : class, IOrder
    {
        private readonly T currentOrder;
        private readonly string userRole;

        public SpotPurchaseOrderStatusProtectionProxy(string userRole, T currentOrder)
        {
            this.userRole = userRole;
            this.currentOrder = currentOrder;
        }

        public T CurrentOrder
        {
            get
            {
                return currentOrder;
            }
        }

        public T UpdateStatus(OrderStatus status)
        {
            if (CheckApproverPermission(status))
            {
                this.CurrentOrder.OrderStatus = status;
            }
            else if (CheckRejectReturnPermission(status))
            {
                this.CurrentOrder.OrderStatus = status;
            }
            else if (CheckReceivePermission(status))
            {
                this.CurrentOrder.OrderStatus = status;
            }

            return this.CurrentOrder;
        }

        private bool CheckApproverPermission(OrderStatus status)
        {
            return (status == OrderStatus.Approved || status == OrderStatus.ForceApproved) 
                   && SpotPurchaseOrderStatusConstrians.ApproverOrForceApproverRoles.Contains(userRole);
        }
        private bool CheckRejectReturnPermission(OrderStatus status)
        {
            return (status == OrderStatus.Rejected || status == OrderStatus.Return)
                    && SpotPurchaseOrderStatusConstrians.RejectOrReturnRoles.Contains(userRole);
        }
        
        private bool CheckReceivePermission(OrderStatus status)
        {
            return (status == OrderStatus.Received && SpotPurchaseOrderStatusConstrians.ReceiverRoles.Contains(userRole));
        }

     
    }
}
