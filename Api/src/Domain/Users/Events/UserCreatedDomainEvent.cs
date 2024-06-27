using Domain.SeedWork;

namespace Domain.Users.Events
{
    public class UserCreatedDomainEvent(string login) : DomainEventBase
    {
        public string Login { get; } = login;
    }
}
