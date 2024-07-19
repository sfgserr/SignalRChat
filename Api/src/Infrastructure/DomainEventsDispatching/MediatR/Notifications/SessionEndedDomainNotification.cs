using Domain.Sessions.Events;
using System.Text.Json.Serialization;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class SessionEndedDomainNotification : DomainNotificationBase<SessionEndedDomainEvent>
    {
        [JsonConstructor]
        public SessionEndedDomainNotification(SessionEndedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
