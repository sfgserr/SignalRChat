using Domain.SeedWork;

namespace Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        private User(UserId userId, string login, string password, string iconUri)
        {
            UserId = userId;
            Login = login;
            Password = password;
            IconUri = iconUri;
        }

        private User()
        {
                   
        }

        internal static User Create(string login, string password, string iconUri)
        {
            return new User(new UserId(Guid.NewGuid()), login, password, iconUri);
        }

        public UserId UserId { get; }

        public string Login { get; }

        public string Password { get; private set; }

        public string IconUri { get; private set; }
    }
}
