using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Burger
{
    public interface IChickenBurger : IBurger
    {
        string Tomato { get; set; }
        string ChickenPatty { get; set; }
        string ChickenCrispy { get; set; }
    }
}
