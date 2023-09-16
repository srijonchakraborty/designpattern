using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Stock
{
    public class Stock
    {
       public string? Id { get; set; }
       public Product? Item{ get; set; }
       public double StockQuantity { get; set; }
    }
}
