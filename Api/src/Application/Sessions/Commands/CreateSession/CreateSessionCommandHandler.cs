using Application.Cqrs.Commands;
using Domain.Sessions;

namespace Application.Sessions.Commands.CreateSession
{
    internal class CreateSessionCommandHandler : ICommandHandler<CreateSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository;

        internal CreateSessionCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task Handle(CreateSessionCommand command)
        {
            await _sessionRepository.Add(Session.CreateSession(command.ProposingUserId, command.ProposedUserId));
        }
    }
}
