using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extentions
{
    public static class OrderExtentions
    {
        public static string GetOrderItemDetails(this IOrder order)
        {
            StringBuilder result =new StringBuilder();
            
            if (order.OrderItems != null)
            {
                int count=1;
                foreach(var item in order.OrderItems)
                {
                    string str = $@"{count}. Item:{item.ItemName} Unit:{item.Unit} Price:{item.Quantity} Supplier:{item.SupplierName}.";
                    result.AppendLine(str);
                    count++;
                }
            }
            return result.ToString();
        }
    }
}
