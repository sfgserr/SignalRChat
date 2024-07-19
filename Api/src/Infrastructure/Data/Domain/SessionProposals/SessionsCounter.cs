using Domain.SessionProposals;
using Domain.Users;

namespace Infrastructure.Data.Domain.SessionProposals
{
    internal class SessionsCounter : ISessionsCounter
    {
        private readonly ApplicationContext _applicationContext;

        internal SessionsCounter(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public int CountUserSessions(UserId userId)
        {
            return _applicationContext.Sessions
                .Where(s => (s.CrossUserId.Equals(userId) || s.NoughtUserId.Equals(userId)) && s.IsEnded == false)
                .Count();
        }
    }
}
