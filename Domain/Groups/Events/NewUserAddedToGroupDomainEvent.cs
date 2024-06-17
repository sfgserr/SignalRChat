using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Events
{
    public class NewUserAddedToGroupDomainEvent(GroupId groupId, UserId userId) : DomainEventBase
    {
        public GroupId GroupId { get; } = groupId;

        public UserId UserId { get; } = userId;
    }
}
