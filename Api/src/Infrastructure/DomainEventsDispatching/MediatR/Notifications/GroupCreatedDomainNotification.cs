using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class GroupCreatedDomainNotification : DomainNotificationBase<GroupCreatedDomainEvent>
    {
        internal GroupCreatedDomainNotification(GroupCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
