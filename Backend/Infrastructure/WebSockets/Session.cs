using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Infrastructure.WebSocket
{
    public class Session
    {
        public string Id { get; }

        public System.Net.WebSockets.WebSocket Socket { get; }

        public Session(string id, System.Net.WebSockets.WebSocket socket)
        {
            Id = id;
            Socket = socket;
        }

        public async Task Service(Func<string, JObject, Task> callback)
        {
            while (Socket.State == WebSocketState.Open)
            {
                var buffer = new byte[1024 * 4];
                var package = new List<byte>();

                WebSocketReceiveResult socketResponse;

                do
                {
                    var arrayBuffer = new ArraySegment<byte>(buffer);
                    socketResponse = await Socket.ReceiveAsync(arrayBuffer, CancellationToken.None);

                    var arrayPackage = new ArraySegment<byte>(buffer, 0, socketResponse.Count);
                    package.AddRange(arrayPackage);
                } while (!socketResponse.EndOfMessage);

                var encoding = Encoding.UTF8;

                var rawMessage = encoding.GetString(package.ToArray());

                if (!string.IsNullOrEmpty(rawMessage))
                {
                    var settings = new JsonLoadSettings{

                     };

                    var jobject = JObject.Parse(rawMessage);

                    if (jobject.ContainsKey("type"))
                    {
                        await callback(jobject["type"].ToObject<string>(), jobject);
                    }
                    else
                    {
                        await InvalidRequest("undefined-type");
                    }
                }
            }
        }

        public async Task AcknowledgeConnection()
        {
            Console.WriteLine($"User {Id} join the game.");

            await Send("acknowledge-connection", Id);
        }

        public async Task InvalidRequest(string type)
        {
            Console.WriteLine($"User sent an invalid request '{type}'.");

            await Send("invalid-request", type);
        }

        public async Task Send(string type) => await Send<Object>(type, null);

        public async Task Send<T>(string type, T payload)
        {
            var message = new Message<T>
            {
                Type = type,
                Payload = payload
            };

            await SendRaw(message.ToJson());
        }

        public async Task SendRaw(string message)
        {
            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(message);
            var array = new ArraySegment<byte>(bytes, 0, bytes.Length);

            await Socket.SendAsync(
                array,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }
}