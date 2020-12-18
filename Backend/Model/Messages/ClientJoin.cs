using Anotations;

namespace Model.Messages
{
    [MessageType("battle-join")]
    public class ClientJoin : ClientMessage
    {
        public string BattleId { get; set; }
    }
}
