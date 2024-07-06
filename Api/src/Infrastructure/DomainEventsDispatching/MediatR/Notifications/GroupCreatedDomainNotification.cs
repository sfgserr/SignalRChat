using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class GroupCreatedDomainNotification : DomainNotificationBase<GroupCreatedDomainEvent>
    {
        public GroupCreatedDomainNotification(GroupCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
