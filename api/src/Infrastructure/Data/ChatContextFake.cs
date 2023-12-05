using Domain;

namespace Infrastructure.Data
{
    public class ChatContextFake
    {
        public ChatContextFake()
        {
            Messages = new List<Message>()
            { 
                new Message(SeedData.DefaultMessageId, SeedData.DefaultUserSenderId, "Hello",
                            DateTime.Now, SeedData.DefaultUserReceiverId) 
            };
        }

        public List<Message> Messages { get; set; }
    }
}
