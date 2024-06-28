using Domain.Users;

namespace Infrastructure.Data.Domain.Users
{
    internal class UserCounter : IUserCounter
    {
        private readonly AppContext _appContext;

        internal UserCounter(AppContext appContext)
        {
            _appContext = appContext;
        }

        public int GetUsersCountWithSameLogin(string login)
        {
            return _appContext.Users.Where(u => u.Login == login).Count();
        }
    }
}
