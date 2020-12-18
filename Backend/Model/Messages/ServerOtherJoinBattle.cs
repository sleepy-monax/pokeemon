using Anotations;
using Model.Battle;

namespace Model.Messages
{
    [MessageType("battle-other-join")]
    public class ServerOtherJoinBattle : ServerBattleMessage
    {
        public Player Player { get; set; }
    }
}