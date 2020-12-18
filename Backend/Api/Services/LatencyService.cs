using System;
using Model.Messages;

namespace Api.Services
{
    public class LatencyService
    {
        public LatencyService(SessionService bs)
        {
            bs.RegisterRequestHandler<ClientPing>( (session, payload) => session.Send(new ServerPongMessage()));
        }
    }
}