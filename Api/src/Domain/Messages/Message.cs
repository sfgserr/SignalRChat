using Domain.Messages.Events;
using Domain.SeedWork;
using Domain.Groups;
using Domain.Users;
using Domain.Messages.Rules;

namespace Domain.Messages
{
    public class Message : Entity, IAggregateRoot
    {
        private Message(
            MessageId id,
            UserId senderId,
            Group toGroup,
            string body,
            MessageType type,
            DateTime creationTime,
            bool isEditted,
            bool isRead)
        {
            CheckRule(new OnlyGroupMemberCanSendMessage(toGroup, senderId));
            CheckRule(new TextMustBeProvidedRule(body));

            Id = id;
            SenderId = senderId;
            ToGroupId = toGroup.Id;
            Body = body;
            Type = type;
            CreationTime = creationTime;
            IsEditted = isEditted;
            IsRead = isRead;

            AddDomainEvent(new MessageCreatedDomainEvent(
                toGroup.Users.Select(u => u.UserId).ToList(),
                senderId,
                toGroup.Id,
                creationTime));
        }

        private Message()
        {
            
        }

        public MessageId Id { get; }

        public UserId SenderId { get; }

        public GroupId ToGroupId { get; }

        public string Body { get; private set; }

        public MessageType Type { get; }

        public DateTime CreationTime { get; }

        public bool IsEditted { get; private set; }

        public bool IsRead { get; private set; }

        internal static Message CreateMessage(
            UserId senderId,
            Group toGroup,
            string body, 
            MessageType type)
        {
            return new Message(
                new MessageId(Guid.NewGuid()), 
                senderId, 
                toGroup, 
                body, 
                type, 
                DateTime.Now, 
                false,
                false);
        }

        public void Edit(UserId edittingUserId, string body)
        {
            CheckRule(new MessageCanBeEdittedOnlyBySenderRule(this, edittingUserId));

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
