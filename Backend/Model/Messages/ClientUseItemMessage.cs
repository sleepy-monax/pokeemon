using Anotations;

namespace Model.Messages
{
    [MessageType("battle-use-item")]
    public class ClientUseItem : ClientMessage
    {
        public string Item { get; set; }
        public bool TargetEnemy { get; set; }
        public int CreatureIndex { get; set; }
    }
}
