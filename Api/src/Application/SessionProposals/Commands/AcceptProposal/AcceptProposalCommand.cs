using Application.Cqrs.Commands;

namespace Application.SessionProposals.Commands.AcceptProposal
{
    public class AcceptProposalCommand : ICommand
    {
        public Guid SessionProposalId { get; }
    }
}
