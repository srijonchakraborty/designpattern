using BuilderPattern.BuilderConcrete.BurgerBuilder;
using Common.Contracts.Burger;
using Common.DTOs.Burger;
using Common.Model.Burger;

namespace BuilderPattern.BuilderDirectors.BurgerDirector
{
    public class VegetableBurgerDirector : IBurgerDirector<VegetableBurgerBuilder, VegetableBurgerDto>
    {
        public VegetableBurgerDirector()
        {
        }

        public IBurger BuildBurger(VegetableBurgerBuilder builder, VegetableBurgerDto options)
        {
          
            IBurger order;
            if (builder != null && options != null)
            {
                builder.SetTomato(options.Tomato);
                builder.SetVegetableFriedPatty(options.VegetableFriedPatty);
                builder.SetVegetableGrilledPatty(options.VegetableGrilledPatty);
                order = builder
                        .SetId(options.Id)
                        .SetBurgerCode(options.BurgerCode)
                        .SetBun(options.Bun)
                        .SetCreateDate(options.CreateDate)
                        .Build();
            }
            else
            {
                order = new VegetableBurger();
            }
            return order;
        }
    }
}
