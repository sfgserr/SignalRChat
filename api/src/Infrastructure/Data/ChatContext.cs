using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);
        }

        public DbSet<Message> Messages { get; set; }
    }
}
