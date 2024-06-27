using Domain.Groups;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Events
{
    public class MessageCreatedDomainEvent(List<UserId> users, UserId senderId, GroupId groupId, DateTime created) : 
        DomainEventBase
    {
        public List<UserId> Users { get; } = users;

        public UserId SenderId { get; } = senderId;

        public GroupId GroupId { get; } = groupId;

        public DateTime Created { get; } = created;
    }
}
