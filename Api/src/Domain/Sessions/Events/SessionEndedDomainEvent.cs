using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class SessionEndedDomainEvent : DomainEventBase
    {
        public SessionEndedDomainEvent(UserId crossUserId, UserId noughtUserId, UserId? winnerUserId)
        {
            WinnerUserId = winnerUserId;
            CrossUserId = crossUserId;
            NoughtUserId = noughtUserId;
        }

        public UserId CrossUserId { get; }

        public UserId NoughtUserId { get; }

        public UserId? WinnerUserId { get; }
    }
}
