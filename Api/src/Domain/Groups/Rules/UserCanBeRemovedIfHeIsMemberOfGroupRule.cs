using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class UserCanBeRemovedIfHeIsMemberOfGroupRule(UserId userId, List<GroupUser> users) : IBusinessRule
    {
        private readonly UserId _userId = userId;
        private readonly List<GroupUser> _users = users;

        public bool IsBroken => !_users.Any(u => u.UserId == _userId);

        public string Message => "User is not in the group";
    }
}
