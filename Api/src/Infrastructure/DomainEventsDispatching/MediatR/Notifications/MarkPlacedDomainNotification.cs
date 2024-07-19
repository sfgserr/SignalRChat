using Domain.Sessions.Events;
using System.Text.Json.Serialization;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class MarkPlacedDomainNotification : DomainNotificationBase<MarkPlacedDomainEvent>
    {
        [JsonConstructor]
        public MarkPlacedDomainNotification(MarkPlacedDomainEvent domainEvent) : base(domainEvent)
        {

        }
    }
}
