namespace Model.Messages
{
    public class ServerAcknowledge : ClientMessage
    {
        public string SessionId { get; }
        
        public ServerAcknowledge(string sessionId)
        {
            SessionId = sessionId;
        }
    }
}