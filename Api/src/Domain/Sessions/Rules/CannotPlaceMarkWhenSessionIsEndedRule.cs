using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Rules
{
    public class CannotPlaceMarkWhenSessionIsEndedRule(UserId? winnerUserId, bool isDraw) : IBusinessRule
    {
        private readonly UserId? _winnerUserId = winnerUserId;
        private readonly bool _isDraw = isDraw;

        public bool IsBroken => _isDraw || _winnerUserId is not null;

        public string Message => "Session is ended";
    }
}
