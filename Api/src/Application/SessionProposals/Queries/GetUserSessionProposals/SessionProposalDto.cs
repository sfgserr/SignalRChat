using Domain.SessionProposals;

namespace Application.SessionProposals.Queries.GetUserSessionProposals
{
    public class SessionProposalDto(SessionProposal proposal)
    {
        public Guid Id { get; } = proposal.Id.Value;

        public Guid ProposingUserId { get; } = proposal.ProposingUserId.Value;

        public Guid ProposedUserId { get; } = proposal.ProposedUserId.Value;

        public DateTime ProposedDate { get; } = proposal.ProposedDate;
    }
}
