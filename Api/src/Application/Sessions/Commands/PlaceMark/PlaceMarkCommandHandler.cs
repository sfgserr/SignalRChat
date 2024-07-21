using Application.Cqrs.Commands;
using Domain.Sessions;
using Domain.Users;

namespace Application.Sessions.Commands.PlaceMark
{
    internal class PlaceMarkCommandHandler : ICommandHandler<PlaceMarkCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ISessionRepository _sessionRepository;

        internal PlaceMarkCommandHandler(IUserContext userContext, ISessionRepository sessionRepository)
        {
            _userContext = userContext;
            _sessionRepository = sessionRepository;
        }

        public async Task Handle(PlaceMarkCommand command)
        {
            Session session = await _sessionRepository.Get(_userContext.Id);

            session.PlaceMark(command.Index, _userContext.Id);

            _sessionRepository.Update(session);
        }
    }
}
