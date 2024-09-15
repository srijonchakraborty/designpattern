using Common.Contracts.Burger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Burger
{
    public class VegetableBurger : IVegetableBurger
    {
        public string Tomato { get; set; }
        public string Onion { get; set; }
        public string VegetableFriedPatty { get; set; }
        public string VegetableGrilledPatty { get; set; }
        public string Id { get; set; }
        public string BurgerCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string Bun { get; set; }
    }
}
