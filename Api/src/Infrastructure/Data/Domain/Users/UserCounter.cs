using Domain.Users;

namespace Infrastructure.Data.Domain.Users
{
    internal class UserCounter : IUserCounter
    {
        private readonly ApplicationContext _appContext;

        internal UserCounter(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public int GetUsersCountWithSameLogin(string login)
        {
            return _appContext.Users.Where(u => u.Login == login).Count();
        }
    }
}
