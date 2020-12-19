using Anotations;

namespace Model.Messages
{
    [MessageType("acknowledge")]
    public class ServerAcknowledge : ClientMessage
    {
        public string SessionId { get; }
        
        public ServerAcknowledge(string sessionId)
        {
            SessionId = sessionId;
        }
    }
}