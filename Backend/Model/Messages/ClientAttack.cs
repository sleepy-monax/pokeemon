using Anotations;

namespace Model.Messages
{
    [MessageType("battle-attack")]
    public class ClientAttack : ClientMessage
    {
        public string Name { get; set; }
    }
}
