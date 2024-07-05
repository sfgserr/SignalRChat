using Domain.Users.Events;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class UserCreatedDomainNotification : DomainNotificationBase<UserCreatedDomainEvent>
    {
        public UserCreatedDomainNotification(UserCreatedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
