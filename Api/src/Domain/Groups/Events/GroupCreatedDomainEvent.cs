using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Events
{
    public class GroupCreatedDomainEvent(GroupId groupId, UserId adminId) : DomainEventBase
    {
        public GroupId GroupId { get; } = groupId;

        public UserId AdminId { get; } = adminId;
    }
}
