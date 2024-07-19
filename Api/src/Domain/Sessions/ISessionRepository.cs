using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<Session> Get(UserId userID);
    }
}
