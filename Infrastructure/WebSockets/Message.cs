using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.WebSocket
{
    public class Message<T>
    {
        public string Type { get; set; }
        public T Payload { get; set; }

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