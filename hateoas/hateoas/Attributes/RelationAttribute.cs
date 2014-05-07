using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hateoas.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RelationAttribute : Attribute
    {
        private readonly string _name;
        public string Href;

        public RelationAttribute(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
