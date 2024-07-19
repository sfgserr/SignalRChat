using Domain.SeedWork;

namespace Domain.Users.Rules
{
    public class UserLoginMustBeUniqueRule(IUsersCounter userCounter, string login) : IBusinessRule
    {
        private readonly IUsersCounter _userCounter = userCounter;
        private readonly string _login = login;

        public bool IsBroken => _userCounter.GetUsersCountWithSameLogin(_login) > 0;

        public string Message => "User with such login already exists";
    }
}
