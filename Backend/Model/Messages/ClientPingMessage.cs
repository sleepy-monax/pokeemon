using Anotations;

namespace Model.Messages
{
    [MessageType("ping")]
    public class ClientPing : ClientMessage
    {
    }
}