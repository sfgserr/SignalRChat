using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Rules
{
    public class OnlyCertainUserCanPlaceCertainMarkRule(UserId userId, UserId placingUserId) : IBusinessRule
    {
        private readonly UserId _userId = userId;
        private readonly UserId _placingUserId = placingUserId;

        public bool IsBroken => !_userId.Equals(_placingUserId);

        public string Message => "You are not able to place such marks";
    }
}
