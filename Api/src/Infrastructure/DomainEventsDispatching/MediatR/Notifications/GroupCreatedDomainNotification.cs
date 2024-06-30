using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class GroupCreatedDomainNotification : DomainNotificationBase
    {
        internal GroupCreatedDomainNotification(GroupCreatedDomainEvent domainEvent) : base(domainEvent.Id)
        {
            DomainEvent = domainEvent;
        }

        public GroupCreatedDomainEvent DomainEvent { get; }
    }
}
