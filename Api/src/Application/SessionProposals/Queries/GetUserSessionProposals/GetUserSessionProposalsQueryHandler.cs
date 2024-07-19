using Application.Cqrs.Queries;
using Domain.SessionProposals;
using Domain.Users;

namespace Application.SessionProposals.Queries.GetUserSessionProposals
{
    internal class GetUserSessionProposalsQueryHandler :
        IQueryHandler<GetUserSessionProposalsQuery, IList<SessionProposalDto>>
    {
        private readonly ISessionProposalRepository _sessionProposalsRepository;
        private readonly IUserContext _userContext;

        internal GetUserSessionProposalsQueryHandler(
            ISessionProposalRepository sessionProposalsRepository, 
            IUserContext userContext)
        {
            _sessionProposalsRepository = sessionProposalsRepository;
            _userContext = userContext;
        }

        public async Task<IList<SessionProposalDto>> Handle(GetUserSessionProposalsQuery query)
        {
            var sessionProposals = await _sessionProposalsRepository.Get(_userContext.Id);

            return sessionProposals.Select(s => new SessionProposalDto(s)).ToList();
        }
    }
}
