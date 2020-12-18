using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.WebSockets
{
    public class Package<T>
    {
        public string Type { get; set; }
        public T Message { get; set; }

        public string ToJson()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.None
            });
        }
    }
}