using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.EntityFrameworkTests
{
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            const string connectionString =
            "Server=localhost;User Id=sa;Password=<YourStrong!Passw0rd>;Database=Accounts;";

            DbContextOptions<ChatContext> options = new DbContextOptionsBuilder<ChatContext>()
                .UseSqlServer(connectionString)
                .Options;

            Context = new ChatContext(options);
            Context.Database.EnsureCreated();
        }

        public ChatContext Context { get; }
    }
}