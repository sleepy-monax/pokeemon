using System;
using Model.Messages;

namespace Api.Services
{
    public class BattleService
    {
        public BattleService(SessionService bs)
        {
            bs.RegisterRequestHandler<ClientCreate>((session, message) =>
            {

            });

            bs.RegisterRequestHandler<ClientJoin>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientLeave>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientAttack>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientUseItem>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientSwitchCreature>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientChat>((session, payload) =>
            {
                Console.WriteLine("Chat: " + payload.Text);
                return bs.Broadcast(payload);
            });
        }
    }
}