using Application.Cqrs.Commands;
using Domain.SessionProposals;

namespace Application.SessionProposals.Commands.SendProposal
{
    public class SendProposalCommand(Guid id, SessionProposalId sessionProposalId) : InternalCommandBase(id)
    {
        internal SessionProposalId SessionProposalId { get; } = sessionProposalId;
    }
}
