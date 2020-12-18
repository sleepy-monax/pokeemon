using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Anotations;
using Infrastructure;
using Infrastructure.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Api.Services
{
    public class SessionService
    {
        private readonly Dictionary<string, Session> _sessions = new Dictionary<string, Session>();
        private readonly Dictionary<string, Func<Session, JObject, Task>> _requestHandlers = new Dictionary<string, Func<Session, JObject, Task>>();
        private IdAllocator _allocator = new IdAllocator("session");

        public void RegisterRequestHandler<T>(Func<Session, T, Task> function)
        {
            if (typeof(T).GetCustomAttributes(
                typeof(MessageTypeAttribute), true
            ).FirstOrDefault() is MessageTypeAttribute attribute)
            {
                _requestHandlers.Add(attribute.TypeName, (session, json) =>
                {
                    var contract = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };

                    var serializer = new JsonSerializer
                    {
                        ContractResolver = contract
                    };

                    var message = json.ToObject<Package<T>>();

                    return function(session, message.Message);
                });
            }
            else
            {
                throw new Exception("The message doesn't have a MessageTypeAttribute attached to it!");
            }
        }
        
        public void RegisterRequestHandler<T>( Action<Session, T> action)
        {
            RegisterRequestHandler<T>( (session, data) =>
            {
                return new Task(() => action(session, data));
            });
        }
        
        public async Task AcceptConnection(WebSocket socket)
        {
            var sessionId = _allocator.Alloc();
            var session = new Session(sessionId, socket);
            _sessions.Add(sessionId, session);

            try
            {
                session.AcknowledgeConnection().Wait();

                await session.Service((type, data) => DispatchRequest(session, type, data));
                
                Console.WriteLine($"User {sessionId} left the game.");
                
                _sessions.Remove(sessionId);
                _allocator.Free(sessionId);

                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Broadcast<T>( T payload)
        {
            foreach (var kv in _sessions)
            {
                await kv.Value.Send(payload);
            }
        }

        private async Task DispatchRequest(Session session, string type, JObject message)
        {
            if (_requestHandlers.ContainsKey(type))
            {
                await _requestHandlers[type](session, message);
            }
            else
            {
                await session.InvalidRequest(type);
            }
        }
    }
}