using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class NewUserAddedToGroupDomainNotification : DomainNotificationBase
    {
        internal NewUserAddedToGroupDomainNotification(NewUserAddedToGroupDomainEvent domainEvent) : base(domainEvent.Id)
        {
            DomainEvent = domainEvent;
        }

        public NewUserAddedToGroupDomainEvent DomainEvent { get; }
    }
}
