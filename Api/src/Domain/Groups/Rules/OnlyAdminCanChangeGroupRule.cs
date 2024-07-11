using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class OnlyAdminCanChangeGroupRule(List<GroupUser> users, UserId changingUserId) : IBusinessRule
    {
        private readonly List<GroupUser> _users = users;
        private readonly UserId _changingUserId = changingUserId;

        public bool IsBroken => 
            !_users.Any(u => u.UserId.Equals(_changingUserId) && u.RoleValue == GroupUserRole.Admin.Value);

        public string Message => "Only admin can change group";
    }
}
