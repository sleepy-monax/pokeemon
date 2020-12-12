using System;
using System.Collections.Generic;
using System.Net.WebSockets;
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
                    socketResponse = await Socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    package.AddRange(new ArraySegment<byte>(buffer, 0, socketResponse.Count));
                } while (!socketResponse.EndOfMessage);

                var bufferAsString = System.Text.Encoding.UTF8.GetString(package.ToArray());

                if (!string.IsNullOrEmpty(bufferAsString))
                {
                    var jobject = JObject.Parse(bufferAsString);

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
            var stringAsBytes = System.Text.Encoding.UTF8.GetBytes(message);
            var byteArraySegment = new ArraySegment<byte>(stringAsBytes, 0, stringAsBytes.Length);
            await Socket.SendAsync(byteArraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}