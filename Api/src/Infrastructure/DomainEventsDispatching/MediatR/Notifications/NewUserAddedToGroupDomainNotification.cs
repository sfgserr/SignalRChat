using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class NewUserAddedToGroupDomainNotification : DomainNotificationBase<NewUserAddedToGroupDomainEvent>
    {
        internal NewUserAddedToGroupDomainNotification(NewUserAddedToGroupDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
