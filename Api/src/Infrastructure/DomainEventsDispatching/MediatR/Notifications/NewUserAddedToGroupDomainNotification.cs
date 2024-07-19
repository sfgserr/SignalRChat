using Domain.Groups.Events;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class NewUserAddedToGroupDomainNotification : DomainNotificationBase<NewUserAddedToGroupDomainEvent>
    {
        [JsonConstructor]
        public NewUserAddedToGroupDomainNotification(NewUserAddedToGroupDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
