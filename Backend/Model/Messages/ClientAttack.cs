using Anotations;

namespace Model.Messages
{
    [MessageType("battle-attack")]
    public class ClientAttack : ClientMessage
    {
        public string AttackName { get; set; }
        
    }
}
