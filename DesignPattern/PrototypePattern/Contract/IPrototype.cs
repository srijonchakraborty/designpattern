using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Contract
{
    public interface IPrototype<T> where T : class
    {
        T? ShallowClone(T current);
        T? DeepClone(T current);
        T? DeepUsingJsonClone(T current);
    }
}
