using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hateoas.Attributes;
using Newtonsoft.Json.Linq;

namespace Hateoas
{
    public class HateoasSerializer
    {
        public string Serialize<T>(T serializable)
        {
            var serializableType = serializable.GetType();
            var properties = serializableType.GetProperties();
            var resource = new JObject();
            var links = new JObject();
            resource["_links"] = links;
            
            foreach (var property in properties)
            {
                resource[property.Name] = new JValue(property.GetValue(serializable));
            }

            var relationAttributes = GetRelationAttributessFromType(serializableType);

            foreach (var relationAttribute in relationAttributes)
            {
                links[relationAttribute.GetName()] = relationAttribute.Href;
            }

            return resource.ToString();
        }

        private IEnumerable<RelationAttribute> GetRelationAttributessFromType(MemberInfo serializableType)
        {
            var relationAttributes = (RelationAttribute[])Attribute.GetCustomAttributes(serializableType, typeof(RelationAttribute));

            return relationAttributes;
        }
    }
}
