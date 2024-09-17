using BuilderPattern.BuilderConcrete.BurgerBuilder;
using BuilderPattern.BuilderDirectors.BurgerDirector;
using Common.Contracts.Burger;
using Common.DTOs.Burger;
using Common.Model.Burger;
using Common.Model.Stock;
using Newtonsoft.Json;
using PrototypePattern.Contract;
using PrototypePattern.Implementation.BurgerPrototype;
using PrototypePattern.Implementation.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class BugerMakeBuilder
    {
        private static readonly IPrototype<ChickenBurger, ChickenBurger> tstocks = new ChickenBurgerPrototype();
        //Burger Order Taker
        public static void BuilderPatternForBurger()
        {

            ChickenBurgerBuilder burgerChickenBuilder = new ChickenBurgerBuilder();
            IBurgerDirector<ChickenBurgerBuilder, ChickenBurgerDto> basicburgerDirector = new ChickenBurgerDirector();

            IBurger burgerChicken = basicburgerDirector.BuildBurger(burgerChickenBuilder, new ChickenBurgerDto()
            {
                Id = "CB001",
                BurgerCode = "CHCKN-01",
                CreateDate = DateTime.Now,
                Bun = "Sesame",
                Tomato = "Sliced",
                ChickenPatty = "Spicy",
                ChickenCrispy = "Yes",
                ExtraFeatures=new ChickenBurgerExtraFeature
                {
                    FeatureOne="A",
                    FeatureTwo = "B",
                    FeatureThree  ="C",
                }
            });

            VegetableBurgerBuilder vegetableBuilder = new VegetableBurgerBuilder();
            IBurgerDirector<VegetableBurgerBuilder, VegetableBurgerDto> basicVegetableburgerDirector = new VegetableBurgerDirector();


            IBurger burgerVeg = basicVegetableburgerDirector.BuildBurger(vegetableBuilder, new VegetableBurgerDto()
            {
                Id = "VB001",
                BurgerCode = "VEG-01",
                CreateDate = DateTime.Now,
                Bun = "Whole Wheat",
                Tomato = "Sliced",
                VegetableFriedPatty = "Spicy",
                VegetableGrilledPatty = "Grilled"
            });

            Console.WriteLine("Chicken: ......");
            Console.WriteLine(JsonConvert.SerializeObject(burgerChicken));


            Console.WriteLine("-------------------------------");
            Console.WriteLine("Veg: ......");
            Console.WriteLine(JsonConvert.SerializeObject(burgerVeg));

            Console.ReadKey();

            var newChickenBurger = burgerChicken as ChickenBurger;

            var chickenBurgerShallow=  tstocks.ShallowClone(newChickenBurger);
            var chickenBurgerDeepClone = tstocks.DeepClone(newChickenBurger);
            var chickenBurgerDeepUsingJsonClone = tstocks.DeepUsingJsonClone(newChickenBurger);

            Console.WriteLine($"");
            Console.WriteLine($"--------------------------------------------");


            Console.WriteLine($"Are newChickenBurger and chickenBurgerShallow the same instance? {ReferenceEquals(newChickenBurger, chickenBurgerShallow)}");
            Console.WriteLine($"Are newChickenBurger and chickenBurgerShallow ExtraFeatures the same instance? {ReferenceEquals(newChickenBurger.ExtraFeatures, chickenBurgerShallow.ExtraFeatures)}");
            
            Console.WriteLine($"Are newChickenBurger and chickenBurgerDeepUsingJsonClone the same instance? {ReferenceEquals(newChickenBurger, chickenBurgerDeepUsingJsonClone)}");
            Console.WriteLine($"Are newChickenBurger and chickenBurgerDeepUsingJsonClone ExtraFeatures the same instance? {ReferenceEquals(newChickenBurger.ExtraFeatures, chickenBurgerDeepUsingJsonClone.ExtraFeatures)}");

            Console.WriteLine($"Are newChickenBurger and chickenBurgerDeepClone  the same instance? {ReferenceEquals(newChickenBurger, chickenBurgerDeepClone)}");
            Console.WriteLine($"Are newChickenBurger and chickenBurgerDeepClone ExtraFeatures  the same instance? {ReferenceEquals(newChickenBurger.ExtraFeatures, chickenBurgerDeepClone.ExtraFeatures)}");


            Console.ReadKey();

        }
    }
}
