using Newtonsoft.Json;
using Common.DTOs.Burger;
using Common.Model.Burger;
using PrototypePattern.Contract;

namespace PrototypePattern.Implementation.BurgerPrototype
{
    public class ChickenBurgerPrototype : IPrototype<ChickenBurger, ChickenBurger>
    {
        public ChickenBurger DeepClone(ChickenBurger current)
        {
            var response = new ChickenBurger()
            {
                Id = current.Id,
                Bun=current.Bun,
                BurgerCode = current.BurgerCode,
                ChickenCrispy = current.ChickenCrispy,
                ChickenPatty = current.ChickenPatty,
                CreateDate = current.CreateDate,
                Tomato=current.Tomato,
                ExtraFeatures = MapExtraFeatures(current.ExtraFeatures),
            };
            return response;
        }

        private ChickenBurgerExtraFeature MapExtraFeatures(ChickenBurgerExtraFeature extraFeatures)
        {
            ChickenBurgerExtraFeature product = new ChickenBurgerExtraFeature()
            {
                FeatureOne = extraFeatures?.FeatureOne,
                FeatureTwo = extraFeatures?.FeatureTwo,
                FeatureThree = extraFeatures?.FeatureThree
            };
            return product;
        }

        public ChickenBurger? DeepUsingJsonClone(ChickenBurger current)
        {
            if (current != null)
            {
                string json = JsonConvert.SerializeObject(current);
                var deserializedObject = JsonConvert.DeserializeObject<ChickenBurger>(json);
                return deserializedObject;
            }
            else
            {
                return new ChickenBurger();
            }
        }
        public ChickenBurger? ShallowClone(ChickenBurger current)
        {
            var response = new ChickenBurger()
            {
                Id = current.Id,
                Bun = current.Bun,
                BurgerCode = current.BurgerCode,
                ChickenCrispy = current.ChickenCrispy,
                ChickenPatty = current.ChickenPatty,
                CreateDate = current.CreateDate,
                Tomato = current.Tomato,
                ExtraFeatures = current.ExtraFeatures,
            };
            return response;
        }
    }
}
