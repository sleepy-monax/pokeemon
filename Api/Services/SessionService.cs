using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.WebSocket;
using Newtonsoft.Json.Linq;

namespace Api.Services
{
    public class SessionService
    {
        private Dictionary<string, Session> _sessions = new Dictionary<string, Session>();
        private Dictionary<string, Func<Session, JObject, Task>> _requestHandlers = new Dictionary<string, Func<Session, JObject, Task>>();

        public void RegisterRequestHandler<T>(string type, Func<Session, T, Task> action)
        {
            _requestHandlers.Add(type, (session, json) =>
            {
                return action(session, json.ToObject<T>());
            });
        }

        string GenerateSessionId()
        {
            var rand = new Random();

            var name = "";

            do
            {
                var random_number = rand.Next(1, int.MaxValue);
                name = $"session-{random_number:X}";
            } while (_sessions.ContainsKey(name));

            return name;
        }

        public async Task AcceptConnection(WebSocket socket)
        {
            var sessionId = GenerateSessionId();
            var session = new Session(sessionId, socket);
            _sessions.Add(sessionId, session);

            try
            {
                session.AcknowledgeConnection().Wait();

                await session.Service((type, data) => DispatchRequest(session, type, data));

                _sessions.Remove(sessionId);

                Console.WriteLine($"User {sessionId} left the game.");

                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Broadcast<T>(string type, T payload)
        {
            foreach (var kv in _sessions)
            {
                await kv.Value.Send(type, payload);
            }
        }

        private async Task DispatchRequest(Session session, string type, JObject payload)
        {
            if (_requestHandlers.ContainsKey(type))
            {
                await _requestHandlers[type](session, payload);
            }
            else
            {
                await session.InvalidRequest(type);
            }
        }
    }
}