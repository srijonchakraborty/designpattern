using BuilderPattern.BuilderInterface;
using Common.Contracts.Burger;
using Common.Model.Burger;

namespace BuilderPattern.BuilderConcrete.BurgerBuilder
{
    public class ChickenBurgerBuilder : BurgerBuilder<IChickenBurger>
    {
        protected override IChickenBurger CreateInstance() => new ChickenBurger();
        public BurgerBuilder<IChickenBurger> SetTomato(string tomato)
        {
            target.Tomato = tomato;
            return this;
        }
        public BurgerBuilder<IChickenBurger> SetChickenPatty(string chickenPatty)
        {
            target.ChickenPatty = chickenPatty;
            return this;
        }
        public BurgerBuilder<IChickenBurger> SetChickenCrispy(string chickenCrispy)
        {
            target.ChickenCrispy = chickenCrispy;
            return this;
        }

    }
}
