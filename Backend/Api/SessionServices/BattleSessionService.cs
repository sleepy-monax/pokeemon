using Infrastructure.WebSockets;
using Model.Battle;

namespace Api.SessionServices
{
    public class BattleSessionService : ISessionService
    {
        public Player Player { get; }
        public Battle Battle { get; }
    }
}