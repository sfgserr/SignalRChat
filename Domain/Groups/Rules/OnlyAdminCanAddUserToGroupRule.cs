using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups.Rules
{
    public class OnlyAdminCanAddUserToGroupRule(List<GroupUser> users, UserId settingUserId) : IBusinessRule
    {
        private readonly List<GroupUser> _users = users;
        private readonly UserId _settingUserId = settingUserId;

        public bool IsBroken => 
            _users.SingleOrDefault(u => u.UserId == _settingUserId && u.Role == GroupUserRole.Admin) == null;

        public string Message => "Only admin can add user to group";
    }
}
