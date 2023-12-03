using Domain.ValueObjects;

namespace Domain
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
        public string ExternalUserReceiverId { get; }
        public string Text { get; }
        public DateTime SentTime { get; }
    }
}
