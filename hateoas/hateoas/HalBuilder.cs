using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hateoas.Attributes;
using Newtonsoft.Json.Serialization;

namespace Hateoas
{
    public class HalBuilder<T>
    {
        public Dictionary<string, string> _links { get; set; }

        public HalBuilder()
        {
            _links = new Dictionary<string, string>();
        }

        public HalBuilder<T> Build(T representation)
        {
            var type = representation.GetType();
            // Get instance of the attribute.
            var relationAttribute = (RelationAttribute)Attribute.GetCustomAttribute(type, typeof(RelationAttribute));

            if (relationAttribute != null)
            {
                _links.Add(relationAttribute.GetName(), relationAttribute.Href);
            }

            return this;
        }
    }
}
