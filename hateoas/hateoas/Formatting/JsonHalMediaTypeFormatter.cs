using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Emken.Formatting
{
    public class JsonHalMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public JsonHalMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json+hal"));
        }

        public override bool CanReadType(Type type)
        {
            throw new NotImplementedException();
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }
    }
}
