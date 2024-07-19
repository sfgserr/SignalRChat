using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals.Rules
{
    public class UsersCannotHaveCurrentSessionsRule
        (ISessionsCounter counter, UserId proposingUserId, UserId proposedUserId) : IBusinessRule
    {
        private readonly ISessionsCounter _counter = counter;
        private readonly UserId _proposingUserId = proposingUserId;
        private readonly UserId _proposedUserId = proposedUserId;

        public bool IsBroken => 
            _counter.CountUserSessions(_proposingUserId) > 0 || _counter.CountUserSessions(_proposedUserId) > 0;

        public string Message => "Users can't have current sessions";
    }
}
