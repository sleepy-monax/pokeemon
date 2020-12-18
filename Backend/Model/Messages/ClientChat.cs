using Anotations;

namespace Model.Messages
{
    [MessageType("battle-chat")]
    public class ClientChat :  ClientMessage
    {
        public string Text { get; set; } = "";
    }
}