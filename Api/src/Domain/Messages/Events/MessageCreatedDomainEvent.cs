
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Events
{
    public class MessageCreatedDomainEvent(UserId senderId, MessageType type, DateTime created) : DomainEventBase
    {
        public UserId SenderId { get; } = senderId;

        public MessageType Type { get; } = type;

        public DateTime Created { get; } = created;
    }
}
