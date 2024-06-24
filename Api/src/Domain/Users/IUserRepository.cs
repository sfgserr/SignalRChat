using Domain.SeedWork;

namespace Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(UserId userId);

        Task<User> Get(string login);
    }
}
