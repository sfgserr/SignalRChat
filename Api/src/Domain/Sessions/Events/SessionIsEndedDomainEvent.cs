using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class SessionIsEndedDomainEvent : DomainEventBase
    {
        public SessionIsEndedDomainEvent(UserId? winnerUserId)
        {
            WinnerUserId = winnerUserId;
        }

        public SessionIsEndedDomainEvent()
        {

        }

        public UserId? WinnerUserId { get; }
    }
}
