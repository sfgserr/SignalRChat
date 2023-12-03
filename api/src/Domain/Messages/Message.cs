using Domain.ValueObjects;

namespace Domain.Messages
{
    public class Message : IMessage
    {
        public Message(MessageId id, string externalUserSenderId, string text, DateTime sentTime)
        {
            Id = id;
            ExternalUserSenderId = externalUserSenderId;
            Text = text;
            SentTime = sentTime;
        }

        public MessageId Id { get; }
        public string ExternalUserSenderId { get; }
        public string Text { get; }
        public DateTime SentTime { get; }
        public RoomId RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
