using Anotations;

namespace Model.Messages
{
    [MessageType("pong")]
    public class ServerPongMessage : ServerMessage
    {
    }
}