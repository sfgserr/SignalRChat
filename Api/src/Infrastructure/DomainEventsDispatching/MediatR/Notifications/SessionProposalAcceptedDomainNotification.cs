using Domain.SessionProposals.Events;
using System.Text.Json.Serialization;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class SessionProposalAcceptedDomainNotification : DomainNotificationBase<SessionProposalAcceptedDomainEvent>
    {
        [JsonConstructor]
        public SessionProposalAcceptedDomainNotification(SessionProposalAcceptedDomainEvent domainEvent) : 
            base(domainEvent)
        {
        }
    }
}
