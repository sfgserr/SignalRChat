using Domain.Groups;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals.Rules
{
    public class UsersMustBeInOneGroupRule(List<GroupUser> groupUsers, UserId proposingUserId, UserId proposedUserId) : IBusinessRule
    {
        private readonly List<GroupUser> _groupUsers = groupUsers;
        private readonly UserId _proposingUserId = proposingUserId;
        private readonly UserId _proposedUserId = proposedUserId;

        public bool IsBroken => 
            !(_groupUsers.Any(u => u.UserId.Equals(_proposingUserId)) && _groupUsers.Any(u => u.Equals(_proposedUserId)));

        public string Message => "Proposing user and Proposed user are not in the same group";
    }
}
