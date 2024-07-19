using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class MarkPlacedDomainEvent(SessionId sessionId, UserId receivingUserId, Mark mark) : DomainEventBase
    {
        public SessionId SessionId { get; } = sessionId;

        public UserId ReceivingUserId { get; } = receivingUserId;

        public Mark Mark { get; } = mark;
    }
}
