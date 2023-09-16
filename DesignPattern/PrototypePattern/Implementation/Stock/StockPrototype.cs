using Common.Model.Stock;
using Newtonsoft.Json;
using PrototypePattern.Contract;
using System;
using CMS=Common.Model.Stock;


namespace PrototypePattern.Implementation.Stock
{
    public class StockPrototype : IPrototype<CMS.Stock>
    {
        public CMS.Stock? DeepClone(CMS.Stock current)
        {
            var response = new CMS.Stock()
            {
                Id = current.Id,
                StockQuantity = current.StockQuantity,
                Item = MapItem(current.Item),
            };
            return response;
        }

        private Product MapItem(Product? item)
        {
            Product product=new Product()
            {
                Id=item?.Id,
                ItemName= item ?.ItemName,
                Unit = item?.Unit 
            };
            return product;
        }

        public CMS.Stock? DeepUsingJsonClone(CMS.Stock current)
        {
            if (current != null)
            {
                string json = JsonConvert.SerializeObject(current);
                var deserializedObject = JsonConvert.DeserializeObject<CMS.Stock>(json);
                return deserializedObject;
            }
            else
            {
                return new CMS.Stock();
            }
        }
        public CMS.Stock? ShallowClone(CMS.Stock current)
        {
            var response = new CMS.Stock() {
                Id = current.Id,
                StockQuantity= current.StockQuantity,
                Item= current.Item,
            };
            return response;
        }
    }
}
