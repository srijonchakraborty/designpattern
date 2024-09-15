using Common.Contracts.Burger;
using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderDirectors.BurgerDirector
{
    public interface IBurgerDirector<T1, T2>
    {
        IBurger BuildBurger(T1 builder, T2 options);
    }
}
