using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class UserCanOnlyBeAddedOnceRule : IBusinessRule
    {
        private readonly UserId _userId;
        private readonly List<GroupUser> _users;

        public UserCanOnlyBeAddedOnceRule(UserId userId, List<GroupUser> users)
        {
            _userId = userId;
            _users = users;
        }

        public bool IsBroken => _users.SingleOrDefault(u => u.UserId == _userId) is null;

        public string Message => "User already added to group";
    }
}
