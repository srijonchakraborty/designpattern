using BuilderPattern.BuilderDirectors.OrderDirector;
using BuilderPattern.BuilderInterface;
using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPattern.BuilderConcrete.OrderBuilder;

namespace DesignPattern.Order
{
    public static class OrderDataCreator
    {
        public static List<IOrder> CreateData()
        {
            List<IOrder> orders = new List<IOrder>();
            orders.AddRange(GeneratePurchaseOrder.GetPOItems());
            orders.AddRange(GenerateSpotPurchase.GetSPOItems());
            orders.AddRange(GenerateLC.GetLCItems());
            return orders;
        }
    }
}
