using Common;
using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderInterface
{
    public abstract class OrderBuilder<T> : GenericBuilder<T> where T : IOrder
    {
        public OrderBuilder<T> SetId(string id)
        {
            target.Id = id;
            return this;
        }
        public OrderBuilder<T> SetOrderStatus(OrderStatus orderStatus)
        {
            target.OrderStatus = orderStatus;
            return this;
        }
        public OrderBuilder<T> SetOrderNo(string orderNo)
        {
            target.OrderNo = orderNo;
            return this;
        }
        public OrderBuilder<T> SetOrders(List<IOrderItem> orders)
        {
            target.OrderItems = orders;
            return this;
        }
        public OrderBuilder<T> SetCreateDate(DateTime createDate)
        {
            target.CreateDate = createDate;
            return this;
        }
        public OrderBuilder<T> SetModifiedDate(DateTime modifiedDate)
        {
            target.ModifiedDate = modifiedDate;
            return this;
        }
        public OrderBuilder<T> SetClientEmail(string clientEmail)
        {
            target.ClientEmail = clientEmail;
            return this;
        }
        public OrderBuilder<T> AddOrderItem(IOrderItem item)
        {
            if (target.OrderItems == null)
            {
                target.OrderItems = new List<IOrderItem>();
            }

            target.OrderItems.Add(item);
            return this;
        }


        public OrderBuilder<T> UpdateOrderItem(string itemId, Action<IOrderItem> updateAction)
        {
            if (target.OrderItems != null)
            {
                var itemToUpdate = target.OrderItems.FirstOrDefault(item => item.ItemId == itemId);
                if (itemToUpdate != null)
                {
                    updateAction(itemToUpdate);
                }
                else
                {
                    throw new ArgumentException($"Item with ItemId '{itemId}' not found in the order.");
                }
            }
            else
            {
                throw new InvalidOperationException("The order does not contain any items.");
            }

            return this;
        }
    }
}
