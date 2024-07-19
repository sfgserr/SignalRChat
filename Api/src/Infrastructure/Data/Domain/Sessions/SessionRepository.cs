using Domain.Sessions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Sessions
{
    internal class SessionRepository : ISessionRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal SessionRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(Session entity)
        {
            await _applicationContext.Sessions.AddAsync(entity);
        }

        public async Task<Session> Get(UserId userId)
        {
            return await _applicationContext.Sessions
                .FirstOrDefaultAsync(s => 
                (s.CrossUserId.Equals(userId) || s.NoughtUserId.Equals(userId)) && !s.IsEnded);
        }

        public async Task<Session> Get(SessionId sessionId)
        {
            return await _applicationContext.Sessions.FirstOrDefaultAsync(s => s.Equals(sessionId));
        }

        public async Task<List<Session>> GetAll()
        {
            return await _applicationContext.Sessions.ToListAsync();
        }
    }
}
