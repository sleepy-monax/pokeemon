using Anotations;
using Model.Battle;

namespace Model.Messages
{
    [MessageType("battle-join")]
    public class ServerJoinBattle : ServerBattleMessage
    {
        public Player Player { get; set; }
    }
}