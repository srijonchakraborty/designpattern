using Common.Model.Stock;
using Newtonsoft.Json;
using PrototypePattern.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementation
{
    public class GenericPrototype<T1, T2> where T1 : class where T2 : class, new()
    {
        public T2 DeepUsingJsonClone(T1 current)
        {
            if (current != null)
            {
                string json = JsonConvert.SerializeObject(current);
                return JsonConvert.DeserializeObject<T2>(json);
            }
            else
            {
                return new T2();
            }
        }
    }
}
