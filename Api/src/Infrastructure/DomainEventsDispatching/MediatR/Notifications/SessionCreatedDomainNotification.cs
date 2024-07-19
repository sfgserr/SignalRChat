using Domain.Sessions.Events;
using System.Text.Json.Serialization;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class SessionCreatedDomainNotification : DomainNotificationBase<SessionCreatedDomainEvent>
    {
        [JsonConstructor]
        public SessionCreatedDomainNotification(SessionCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
