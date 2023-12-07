using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Message : IMessage
    {
        public Message(MessageId id, string externalUserSenderId, string externalUserReceiverId, string text, DateTime sentTime)
        {
            Id = id;
            ExternalUserSenderId = externalUserSenderId;
            Text = text;
            SentTime = sentTime;
            ExternalUserReceiverId = externalUserReceiverId;
        }

        public MessageId Id { get; }
        public string ExternalUserSenderId { get; }
        public string ExternalUserReceiverId { get; }
        public string Text { get; set; }
        public DateTime SentTime { get; }
    }
}
