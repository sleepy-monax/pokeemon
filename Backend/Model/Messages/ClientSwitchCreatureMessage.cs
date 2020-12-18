using Anotations;

namespace Model.Messages
{
    [MessageType("battle-switch-creature")]
    public class ClientSwitchCreature : ClientMessage
    {
        public int CreatureIndex { get; set; }
    }
}
