using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hateoas
{
    public class HateoasSerializerBuilder
    {
        public HateoasSerializer Build()
        {
            return new HateoasSerializer();
        }
    }
}
