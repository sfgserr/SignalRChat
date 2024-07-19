using Domain.SeedWork;

namespace Domain.Sessions.Rules
{
    public class CannotPlaceMarkWhenSessionIsEndedRule(bool isEnded) : IBusinessRule
    {
        private readonly bool _isEnded = isEnded;

        public bool IsBroken => !_isEnded;

        public string Message => "Session is ended";
    }
}
