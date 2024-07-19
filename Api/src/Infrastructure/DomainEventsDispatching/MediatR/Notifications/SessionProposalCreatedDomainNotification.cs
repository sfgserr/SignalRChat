using Domain.SessionProposals.Events;
using System.Text.Json.Serialization;

namespace Infrastructure.DomainEventsDispatching.MediatR.Notifications
{
    internal class SessionProposalCreatedDomainNotification : DomainNotificationBase<SessionProposalCreatedDomainEvent>
    {
        [JsonConstructor]
        public SessionProposalCreatedDomainNotification(SessionProposalCreatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
