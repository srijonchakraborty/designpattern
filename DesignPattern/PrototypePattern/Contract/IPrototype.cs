using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Contract
{
    public interface IPrototype<TInputType,TOutputType> 
        where TInputType : class 
        where TOutputType : class
    {
        TOutputType? ShallowClone(TInputType current);
        TOutputType? DeepClone(TInputType current);
        TOutputType? DeepUsingJsonClone(TInputType current);
    }
}
