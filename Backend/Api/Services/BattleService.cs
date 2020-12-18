using System.Collections.Generic;
using Model.Battle;

namespace Api.Services
{
    class BattleService
    {
        private readonly Dictionary<string, Battle> _battles;

        public BattleService(SessionService bs)
        {
            /* bs.RegisterRequestHandler<Model.Chat.Message>("battle-create", (session, payload) =>
             {
             });

             bs.RegisterRequestHandler<Model.Chat.Message>("battle-join", (session, payload) =>
             {
             });

             bs.RegisterRequestHandler<Model.Chat.Message>("battle-leave", (session, payload) =>
             {
             });

             bs.RegisterRequestHandler<Model.Chat.Message>("battle-attack", (session, payload) =>
             {
             });

             bs.RegisterRequestHandler<Model.Chat.Message>("battle-useitem", (session, payload) =>
             {
             });

             bs.RegisterRequestHandler<Model.Chat.Message>("battle-switch", (session, payload) =>
             {
             });*/
        }
    }
}