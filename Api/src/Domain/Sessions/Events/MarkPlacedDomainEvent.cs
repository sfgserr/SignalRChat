using Domain.SeedWork;
using Domain.Users;

namespace Domain.Sessions.Events
{
    public class MarkPlacedDomainEvent(int index, Mark mark, UserId placedUserId) : DomainEventBase
    {
        public int Index { get; } = index;

        public Mark Mark { get; } = mark;

        public UserId PlacedUserId { get; } = placedUserId;
    }
}
