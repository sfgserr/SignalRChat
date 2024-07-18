using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class SessionIsEndedDomainEvent(UserId winnerUserId) : DomainEventBase
    {
        public UserId WinnerUserId { get; } = winnerUserId;
    }
}
