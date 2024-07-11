using Domain.Groups.Events;
using Newtonsoft.Json;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class GroupCreatedDomainNotification : DomainNotificationBase<GroupCreatedDomainEvent>
    {
        [JsonConstructor]
        public GroupCreatedDomainNotification(GroupCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
