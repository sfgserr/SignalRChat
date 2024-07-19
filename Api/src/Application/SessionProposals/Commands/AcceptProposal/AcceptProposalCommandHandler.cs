using Application.Cqrs.Commands;
using Domain.SessionProposals;
using Domain.Users;

namespace Application.SessionProposals.Commands.AcceptProposal
{
    internal class AcceptProposalCommandHandler : ICommandHandler<AcceptProposalCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ISessionProposalRepository _sessionProposalRepository;

        internal AcceptProposalCommandHandler(
            IUserContext userContext, 
            ISessionProposalRepository sessionProposalRepository)
        {
            _userContext = userContext;
            _sessionProposalRepository = sessionProposalRepository;
        }

        public async Task Handle(AcceptProposalCommand command)
        {
            SessionProposal proposal = await _sessionProposalRepository
                .Get(new SessionProposalId(command.SessionProposalId));

            proposal.AcceptProposal(_userContext.Id);
        }
    }
}
