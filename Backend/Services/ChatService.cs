using System;

namespace Backend.Services
{
    public class ChatService
    {
        public ChatService(SessionService bs)
        {
            bs.RegisterRequestHandler<Model.Chat.Message>("chat-message", (session, payload) =>
            {
                Console.WriteLine("Chat: " + payload.Text);
                return bs.Broadcast("chat-message", payload);
            });
        }
    }
}