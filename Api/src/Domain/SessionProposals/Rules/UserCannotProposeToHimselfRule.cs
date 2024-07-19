using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals.Rules
{
    public class UserCannotProposeToHimselfRule(UserId proposingUserId, UserId proposedUserId) : IBusinessRule
    {
        private readonly UserId _proposingUserId = proposingUserId;
        private readonly UserId _proposedUserId = proposedUserId;

        public bool IsBroken => _proposedUserId.Equals(_proposingUserId);

        public string Message => "You cannot propose to yourself";
    }
}
