using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals.Events
{
    public class SessionProposalAcceptedDomainEvent(UserId proposingUserId, UserId proposedUserId) : DomainEventBase
    {
        public UserId ProposingUserId { get; } = proposingUserId;

        public UserId ProposedUserId { get; } = proposedUserId;
    }
}
