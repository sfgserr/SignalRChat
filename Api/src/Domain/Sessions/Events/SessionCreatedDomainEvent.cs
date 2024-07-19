using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class SessionCreatedDomainEvent(SessionId sessionId, UserId crossUserId, UserId noughtUserId) : DomainEventBase
    {
        public SessionId SessionId { get; } = sessionId;

        public UserId CrossUserId { get; } = crossUserId;

        public UserId NoughtUserId { get; } = noughtUserId;
    }
}
