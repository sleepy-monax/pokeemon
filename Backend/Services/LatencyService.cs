using System;

namespace Backend.Services
{
    public class LatencyService
    {
        public LatencyService(SessionService bs)
        {
            bs.RegisterRequestHandler<object>("ping", (session, payload) =>
            {
                return session.Send("pong");
            });
        }
    }
}