using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Rules
{
    public class CannotPlaceMarkWhenSessionIsEndedRule(UserId? winnerUserId) : IBusinessRule
    {
        private readonly UserId? _winnerUserId = winnerUserId;

        public bool IsBroken => _winnerUserId is not null;

        public string Message => "Session is ended";
    }
}
