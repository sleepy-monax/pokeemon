using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anotations;
using Model.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.WebSockets
{
    public class Session
    {
        public string Id { get; }
        public System.Net.WebSockets.WebSocket Socket { get; }
        public List<ISessionService> _Services = new List<ISessionService>();

        public void WithService<T>(Action<T> callback) where T : ISessionService
        {
            foreach (var srv in _Services)
            {
                if (srv is T casted)
                {
                    callback(casted);
                    return;
                }
            }
        }

        public void MountService<T>(T service) where T : ISessionService
        {
            if (_Services.Any(srv => srv is T))
            {
                _Services.RemoveAll(service => service is T);
            }

            _Services.Append(service);
        }

        public void UnMountService<T>() where T : ISessionService
        {
            _Services.RemoveAll(service => service is T);
        }

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

                if (string.IsNullOrEmpty(rawMessage)) continue;
                
                var rawJson = JObject.Parse(rawMessage);

                if (rawJson.ContainsKey("type"))
                {
                    await callback(rawJson["type"].ToObject<string>(), rawJson);
                }
                else
                {
                    await InvalidRequest("undefined-type");
                }
            }
        }

        public async Task AcknowledgeConnection()
        {
            Console.WriteLine($"User {Id} join the game.");

            await Send(new ServerAcknowledge(Id));
        }

        public async Task InvalidRequest(string type)
        {
            Console.WriteLine($"User sent an invalid request '{type}'.");

            await Send(new ServerError("invalid-request"));
        }
        
        public async Task Send<T>(T payload)
        {
            if (typeof(T).GetCustomAttributes(
                typeof(MessageTypeAttribute), true
            ).FirstOrDefault() is MessageTypeAttribute attribute)
            {
                var pkg = new Package<T>
                {
                    Type = attribute.TypeName,
                    Message = payload
                };
                
                await SendRaw(pkg.ToJson());
            }
            else
            {
                throw new Exception("The message doesn't have a MessageTypeAttribute attached to it!");
            }
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