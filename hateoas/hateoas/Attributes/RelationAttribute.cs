using System;

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
