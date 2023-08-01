using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Order
{
    public interface ILC : IOrder
    {
        string BankName { get; set; }
        string BankEmail { get; set; }
    }
}
