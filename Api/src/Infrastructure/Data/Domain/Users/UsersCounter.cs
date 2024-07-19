using Domain.Users;

namespace Infrastructure.Data.Domain.Users
{
    internal class UsersCounter : IUsersCounter
    {
        private readonly ApplicationContext _appContext;

        internal UsersCounter(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public int GetUsersCountWithSameLogin(string login)
        {
            return _appContext.Users.Where(u => u.Login == login).Count();
        }
    }
}
