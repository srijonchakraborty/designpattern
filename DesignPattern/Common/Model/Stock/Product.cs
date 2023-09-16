using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Stock
{
    public class Product 
    {
       public string? Id { get; set; }
       public string? ItemName { get; set; }
       public string? Unit { get; set; }
    }
}
