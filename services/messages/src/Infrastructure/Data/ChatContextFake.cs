using Domain;

namespace Infrastructure.Data
{
    public class ChatContextFake
    {
        public ChatContextFake()
        {
            Messages = new List<Message>()
            { 
                new Message(SeedData.DefaultMessageId, SeedData.DefaultUserSenderId, SeedData.DefaultUserReceiverId,
                            "Hello", DateTime.Now) 
            };
        }

        public List<Message> Messages { get; set; }
    }
}
