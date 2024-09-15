using Common.Contracts.Burger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Burger
{
    public class ChickenBurger : IChickenBurger
    {
        public string Tomato { get ; set; }
        public string ChickenPatty { get; set; }
        public string ChickenCrispy { get; set; }
        public string Id { get; set; }
        public string BurgerCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string Bun { get; set; }
    }
}
