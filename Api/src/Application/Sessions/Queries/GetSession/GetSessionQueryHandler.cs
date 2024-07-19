using Application.Cqrs.Queries;
using Domain.Sessions;
using Domain.Users;

namespace Application.Sessions.Queries.GetSession
{
    internal class GetSessionQueryHandler : IQueryHandler<GetSessionQuery, SessionDto>
    {
        private readonly IUserContext _userContext;
        private readonly ISessionRepository _sessionRepository;

        internal GetSessionQueryHandler(IUserContext userContext, ISessionRepository sessionRepository)
        {
            _userContext = userContext;
            _sessionRepository = sessionRepository;
        }

        public async Task<SessionDto> Handle(GetSessionQuery query)
        {
            var session = await _sessionRepository.Get(_userContext.Id);

            return new SessionDto(session);
        }
    }
}
