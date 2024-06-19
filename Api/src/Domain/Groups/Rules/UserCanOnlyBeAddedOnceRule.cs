using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class UserCanOnlyBeAddedOnceRule(UserId userId, List<GroupUser> users) : IBusinessRule
    {
        private readonly UserId _userId = userId;
        private readonly List<GroupUser> _users = users;

        public bool IsBroken => _users.SingleOrDefault(u => u.UserId == _userId) is null;

        public string Message => "User already added to group";
    }
}
