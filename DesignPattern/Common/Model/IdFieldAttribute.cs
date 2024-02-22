using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdFieldAttribute : Attribute
    {
        public string FieldName { get; }

        public IdFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
