using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Rules
{
    public class CannotPlaceMarkWhenItIsNotTurnRule(bool isCrossTurn, UserId placingUserId, UserId crossUserId) : 
        IBusinessRule
    {
        public bool IsBroken => isCrossTurn ? !placingUserId.Equals(crossUserId) : placingUserId.Equals(crossUserId);

        public string Message => "It's not your turn to place mark";
    }
}
