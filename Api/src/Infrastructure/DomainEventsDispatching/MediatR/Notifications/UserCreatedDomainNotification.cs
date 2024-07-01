using Domain.Users.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class UserCreatedDomainNotification : DomainNotificationBase<UserCreatedDomainEvent>
    {
        internal UserCreatedDomainNotification(UserCreatedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
