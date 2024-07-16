using Domain.Messages;

namespace WebApi.Chat.Messages
{
    public class CreateMessageRequest
    {
        public Guid ToGroupId { get; set; }

        public string Body { get; set; } = string.Empty;

        public MessageType Type { get; set; }
    }
}
