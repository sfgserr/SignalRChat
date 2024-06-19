
namespace Domain.Users.Events
{
    public class UserCreatedDomainEvent(UserId userId)
    {
        public UserId UserId { get; } = userId;
    }
}
