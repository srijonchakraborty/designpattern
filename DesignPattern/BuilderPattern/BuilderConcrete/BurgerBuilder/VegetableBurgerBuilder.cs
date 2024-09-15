using BuilderPattern.BuilderInterface;
using Common.Contracts.Burger;
using Common.Model.Burger;

namespace BuilderPattern.BuilderConcrete.BurgerBuilder
{
    public class VegetableBurgerBuilder : BurgerBuilder<IVegetableBurger>
    {
        protected override IVegetableBurger CreateInstance() => new VegetableBurger();
        public BurgerBuilder<IVegetableBurger> SetTomato(string tomato)
        {
            target.Tomato = tomato;
            return this;
        }
        public BurgerBuilder<IVegetableBurger> SetVegetableFriedPatty(string vegetableFriedPatty)
        {
            target.VegetableFriedPatty = vegetableFriedPatty;
            return this;
        }
        public BurgerBuilder<IVegetableBurger> SetVegetableGrilledPatty(string vegetableGrilledPatty)
        {
            target.VegetableGrilledPatty = vegetableGrilledPatty;
            return this;
        }
    }
}
