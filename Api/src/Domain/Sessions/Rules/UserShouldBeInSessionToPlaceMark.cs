using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Rules
{
    public class UserShouldBeInSessionToPlaceMark(UserId placingUserId, UserId crossUserId, UserId noughUserId) : 
        IBusinessRule
    {
        public bool IsBroken => !placingUserId.Equals(crossUserId) || !placingUserId.Equals(noughUserId);

        public string Message => "You are not able to place such marks";
    }
}
