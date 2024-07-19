using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals.Rules
{
    public class AcceptingUserMustBeProposedRule(UserId acceptingUserId, UserId proposedUserId) : IBusinessRule
    {
        private readonly UserId _acceptingUserId = acceptingUserId;
        private readonly UserId _proposedUserId = proposedUserId;

        public bool IsBroken => !_acceptingUserId.Equals(_proposedUserId);

        public string Message => "You are not proposed";
    }
}
