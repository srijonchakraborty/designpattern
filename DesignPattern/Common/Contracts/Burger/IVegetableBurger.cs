using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Burger
{
    public interface IVegetableBurger: IBurger
    {
        string Tomato { get; set; }
        string VegetableFriedPatty { get; set; }
        string VegetableGrilledPatty { get; set; }
    }
}
