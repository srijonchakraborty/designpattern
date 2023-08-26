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
    public class PurchaseOrderStatusProtectionProxy<T> : IOrderStatusProtectionProxy<T> where T : class, IOrder
    {
        private readonly T currentOrder;
        private readonly string userRole;

        public PurchaseOrderStatusProtectionProxy(string userRole, T currentOrder)
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
            else if (CheckCancelOrRejectPermission(status))
            {
                this.CurrentOrder.OrderStatus = status;
            }
            else if (CheckForwardPermission(status))
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
                   && PurchaseOrderStatusConstrians.ApproverOrForceApproverRoles.Contains(userRole);
        }
        private bool CheckCancelOrRejectPermission(OrderStatus status)
        {
            return (status == OrderStatus.Cancelled || status == OrderStatus.Rejected || status == OrderStatus.Return)
                    && PurchaseOrderStatusConstrians.CancelOrRejectOrReturnRoles.Contains(userRole);
        }
        private bool CheckForwardPermission(OrderStatus status)
        {
            return (status == OrderStatus.Forward && PurchaseOrderStatusConstrians.ForwardRoles.Contains(userRole));
        }
        private bool CheckReceivePermission(OrderStatus status)
        {
            return (status == OrderStatus.Received && PurchaseOrderStatusConstrians.ReceiverRoles.Contains(userRole));
        }

     
    }
}
