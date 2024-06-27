using Domain.Groups;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Events
{
    public class MessageCreatedDomainEvent(List<UserId> users, GroupId groupId, MessageType type, DateTime created) : 
        DomainEventBase
    {
        public List<UserId> Users { get; } = users;

        public GroupId GroupId { get; } = groupId;

        public MessageType Type { get; } = type;

        public DateTime Created { get; } = created;
    }
}
