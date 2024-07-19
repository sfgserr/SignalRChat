using Application.Cqrs.Commands;
using Domain.Sessions;

namespace Application.Sessions.Commands.CheckWin
{
    internal class CheckWinCommandHandler : ICommandHandler<CheckWinCommand>
    {
        private readonly ISessionRepository _sessionRepository;

        internal CheckWinCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task Handle(CheckWinCommand command)
        {
            Session session = await _sessionRepository.Get(command.SessionId);

            session.CheckWin();
        }
    }
}
