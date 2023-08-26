using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Contracts.ProtectionProxy.OrderProtection
{
    public interface IOrderStatusProtectionProxy<T>
    {
        T CurrentOrder { get; }
        T UpdateStatus(OrderStatus status);
    }
}
