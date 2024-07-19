using Domain.SeedWork;

namespace Domain.SessionProposals.Events
{
    public class SessionProposalCreatedDomainEvent(SessionProposalId sessionProposalId) : DomainEventBase
    {
        public SessionProposalId SessionProposalId { get; } = sessionProposalId;
    }
}
