using Domain.SeedWork;
using Domain.Users.Events;
using Domain.Users.Rules;

namespace Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        private User(UserId userId, string login, string password, string iconUri, IUserCounter _usersCounter)
        {
            CheckRule(new UserLoginMustBeUniqueRule(_usersCounter, login));

            Id = userId;
            Login = login;
            Password = password;
            IconUri = iconUri;

            AddDomainEvent(new UserCreatedDomainEvent(login));
        }

        private User()
        {
                   
        }

        public static User Create(string login, string password, string iconUri, IUserCounter userCounter)
        {
            return new User(new UserId(Guid.NewGuid()), login, password, iconUri, userCounter);
        }

        public UserId Id { get; }

        public string Login { get; }

        public string Password { get; private set; }

        public string IconUri { get; private set; }
    }
}
