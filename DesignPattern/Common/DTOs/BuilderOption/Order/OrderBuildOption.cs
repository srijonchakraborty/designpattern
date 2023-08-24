using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.BuilderOption.Order
{
    public class OrderBuildOption
    {
        public string Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderNo { get; set; }
        public List<IOrderItem> Items { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
