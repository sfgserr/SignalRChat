using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class OnlyAdminCanChangeGroupRule(List<GroupUser> users, UserId changingUserId) : IBusinessRule
    {
        private readonly List<GroupUser> _users = users;
        private readonly UserId _changingUserId = changingUserId;

        public bool IsBroken => 
            _users.SingleOrDefault(u => u.UserId == _changingUserId && u.Role == GroupUserRole.Admin) == null;

        public string Message => "Only admin can change group";
    }
}
