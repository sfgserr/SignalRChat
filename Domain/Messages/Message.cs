using Domain.Messages.Events;
using Domain.SeedWork;
using Domain.Groups;
using Domain.Users;

namespace Domain.Messages
{
    public class Message : Entity
    {
        private Message(
            MessageId id,
            UserId senderId,
            GroupId toGroupId,
            string body,
            MessageType type,
            DateTime creationTime,
            bool isEditted,
            bool isRead)
        {
            Id = id;
            SenderId = senderId;
            ToGroupId = toGroupId;
            Body = body;
            Type = type;
            CreationTime = creationTime;
            IsEditted = isEditted;
            IsRead = isRead;

            AddDomainEvent(new MessageCreatedDomainEvent(senderId, type, creationTime));
        }

        private Message()
        {
            
        }

        public MessageId Id { get; }

        public UserId SenderId { get; }

        public GroupId ToGroupId { get; }

        public Group? ToGroup { get; set; }

        public string Body { get; private set; }

        public MessageType Type { get; }

        public DateTime CreationTime { get; }

        public bool IsEditted { get; private set; }

        public bool IsRead { get; private set; }

        internal static Message CreateMessage(
            UserId senderGuid,
            GroupId toGroupId,
            string body, 
            MessageType type)
        {
            return new Message(
                new MessageId(Guid.NewGuid()), 
                senderGuid, 
                toGroupId, 
                body, 
                type, 
                DateTime.Now, 
                false,
                false);
        }

        public void Edit(string body)
        {
            Body = body;
            IsEditted = true;
        }

        public void Read()
        {
            IsRead = true;
        }
    }

    public enum MessageType
    {
        Text = 1,
        Image = 2
    }
}
