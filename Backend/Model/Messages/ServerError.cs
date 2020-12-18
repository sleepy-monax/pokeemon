using Anotations;

namespace Model.Messages
{
    [MessageType("error")]
    public class ServerError : ServerMessage
    {
        public string Message { get; }

        public ServerError(string message)
        {
            Message = message;
        }
    }
}