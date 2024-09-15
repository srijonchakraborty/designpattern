using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Burger
{
    public interface IBurger
    {
        string Id { get; set; }
        string BurgerCode { get; set; }
        DateTime CreateDate { get; set; }
        string Bun { get; set; }
    }
}
