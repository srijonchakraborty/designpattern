using BuilderPattern.BuilderConcrete.BurgerBuilder;
using Common.Contracts.Burger;
using Common.Contracts.Order;
using Common.DTOs.Burger;
using Common.Model.Burger;
using Common.Model.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderDirectors.BurgerDirector
{
    public class ChickenBurgerDirector : IBurgerDirector<ChickenBurgerBuilder, ChickenBurgerDto>
    {
        public ChickenBurgerDirector()
        {
        }

        public IBurger BuildBurger(ChickenBurgerBuilder builder, ChickenBurgerDto options)
        {
            IBurger order;
            if (builder != null && options != null)
            {
                builder.SetTomato(options.Tomato);
                builder.SetChickenPatty(options.ChickenPatty);
                builder.SetChickenCrispy(options.ChickenCrispy);
                order = builder
                        .SetId(options.Id)
                        .SetBurgerCode(options.BurgerCode)
                        .SetBun(options.Bun)
                        .SetCreateDate(options.CreateDate)
                        .Build();
            }
            else
            {
                order = new ChickenBurger();
            }
            return order;
        }

     
    }
}
