using Domain.SeedWork;

namespace Domain.Users
{
    public class User : Entity
    {
        private User(UserId userId, string name, string iconUri)
        {
            UserId = userId;
            Name = name;
            IconUri = iconUri;
        }

        private User()
        {
               
        }

        internal static User Create(string name, string iconUri)
        {
            return new User(new UserId(Guid.NewGuid()), name, iconUri);
        }

        public UserId UserId { get; }

        public string Name { get; private set; }

        public string IconUri { get; private set; }
    }
}
