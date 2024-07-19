using Application.Cqrs.Commands;

namespace Application.SessionProposals.Commands.AcceptProposal
{
    public class AcceptProposalCommand(Guid sessionProposalId) : ICommand
    {
        public Guid SessionProposalId { get; } = sessionProposalId;
    }
}
