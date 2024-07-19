using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.SessionProposals;

namespace Application.SessionProposals.Commands.SendProposal
{
    internal class SendProposalCommandHandler : ICommandHandler<SendProposalCommand>
    {
        private readonly ISessionProposalRepository _sessionProposalRepository;
        private readonly ISender _sender;

        internal SendProposalCommandHandler(ISessionProposalRepository sessionProposalRepository, ISender sender)
        {
            _sessionProposalRepository = sessionProposalRepository;
            _sender = sender;
        }

        public async Task Handle(SendProposalCommand command)
        {
            SessionProposal proposal = await _sessionProposalRepository
                .Get(command.SessionProposalId);

            await _sender.Send(new SessionProposalDto(proposal));
        }
    }
}
