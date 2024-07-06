using Domain.Groups.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class NewUserAddedToGroupDomainNotification : DomainNotificationBase<NewUserAddedToGroupDomainEvent>
    {
        public NewUserAddedToGroupDomainNotification(NewUserAddedToGroupDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
