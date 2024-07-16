using Domain.Groups;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Events
{
    public class MessageCreatedDomainEvent(UserId senderId, GroupId toGroupId, string body, MessageType type) : 
        DomainEventBase
    {
        public UserId SenderId { get; } = senderId;

        public GroupId ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public MessageType Type { get; } = type;
    }
}
