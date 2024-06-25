using Domain.SeedWork;

namespace Domain.Users.Events
{
    public class UserCreatedDomainEvent(UserId userId) : DomainEventBase
    {
        public UserId UserId { get; } = userId;
    }
}
