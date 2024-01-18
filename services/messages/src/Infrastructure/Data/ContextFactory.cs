using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<ChatContext>
    {
        private readonly IConfiguration _configuration;

        public ContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ChatContext CreateDbContext(string[] args)
        {
            string connectionString = _configuration["Database:ConnectionString"];

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            builder.UseSqlServer(connectionString);

            return new ChatContext(builder.Options);
        }
    }
}
