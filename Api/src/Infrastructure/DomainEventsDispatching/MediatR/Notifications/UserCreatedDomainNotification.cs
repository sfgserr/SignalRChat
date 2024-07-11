using Domain.Users.Events;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class UserCreatedDomainNotification : DomainNotificationBase<UserCreatedDomainEvent>
    {
        [JsonConstructor]
        public UserCreatedDomainNotification(UserCreatedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
