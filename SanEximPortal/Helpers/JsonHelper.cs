using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SanEximPortal.Helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerSettings jsonSerializerSettings => new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver() { NamingStrategy = null }
        };
    }
}
