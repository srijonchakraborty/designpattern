using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderInterface
{
    public abstract class GenericBuilder<T>
    {
        protected T target;

        public GenericBuilder()
        {
            target = CreateInstance();
        }

        protected abstract T CreateInstance();

        public T Build() => target;
    }
}
