using Common.Contracts.Order;
using Common.DTOs.BuilderOption.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderDirectors.OrderDirector
{
    public interface IOrderDirector<T1,T2>
    {
        IOrder BuildOrder(T1 builder, T2 options);
    }
}
