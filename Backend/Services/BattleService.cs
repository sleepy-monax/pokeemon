using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.WebSocket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backend.Services
{
    class BattleService
    {
        private Dictionary<string, WebSocket> _users = new Dictionary<string, WebSocket>();
        private Dictionary<string, Func<JObject, Task>> _requestHandlers = new Dictionary<string, Func<JObject, Task>>();

        void RegisterRequestHandler<T>(string type, Func<T, Task> action)
        {
            _requestHandlers.Add(type, json => action(json.ToObject<T>()));
        }

        string GenerateSessionId()
        {
            var rand = new Random();

            var name = "";

            do
            {
                var random_number = rand.Next(1, int.MaxValue);
                name = $"session-{random_number:X}";
            } while (_users.ContainsKey(name));

            return name;
        }

        public async Task AddUser(WebSocket socket)
        {
            try
            {
                var sessionId = GenerateSessionId();

                _users.Add(sessionId, socket);
                AcknowledgeConnection(sessionId, socket).Wait();

                while (socket.State == WebSocketState.Open)
                {
                    var buffer = new byte[1024 * 4];
                    var package = new List<byte>();

                    WebSocketReceiveResult socketResponse;

                    do
                    {
                        socketResponse = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        package.AddRange(new ArraySegment<byte>(buffer, 0, socketResponse.Count));
                    } while (!socketResponse.EndOfMessage);

                    var bufferAsString = System.Text.Encoding.UTF8.GetString(package.ToArray());

                    if (!string.IsNullOrEmpty(bufferAsString))
                    {
                        var jobject = JObject.Parse(bufferAsString);

                        if (jobject.ContainsKey("type"))
                        {
                            await DispatchRequest(jobject["type"].ToObject<string>(), jobject, socket);
                        }
                        else
                        {
                            await InvalidRequest("undefined-type", socket);
                        }
                    }
                }

                _users.Remove(sessionId);
                Console.WriteLine($"User {sessionId} left the game.");

                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Send(string message, params WebSocket[] socketsToSendTo)
        {
            var sockets = socketsToSendTo.Where(s => s.State == WebSocketState.Open);
            foreach (var theSocket in sockets)
            {
                var stringAsBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var byteArraySegment = new ArraySegment<byte>(stringAsBytes, 0, stringAsBytes.Length);
                await theSocket.SendAsync(byteArraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task Send<T>(string type, T payload, params WebSocket[] sockets)
        {
            var message = new Message<T>
            {
                Type = type,
                Payload = payload
            };

            await Send(message.ToJson(), sockets);
        }

        private async Task AcknowledgeConnection(string sessionId, WebSocket socket)
        {
            Console.WriteLine($"User {sessionId} join the game.");

            await Send("acknowledge-connection", sessionId, socket);
        }

        private async Task InvalidRequest(string type, WebSocket socket)
        {
            Console.WriteLine($"User sent an invalid request '{type}'.");

            await Send("invalid-request", type, socket);
        }

        private async Task DispatchRequest(string type, JObject payload, WebSocket socket)
        {
            if (_requestHandlers.ContainsKey(type))
            {
                await _requestHandlers[type](payload);
            }
            else
            {
                await InvalidRequest(type, socket);
            }
        }
    }
}