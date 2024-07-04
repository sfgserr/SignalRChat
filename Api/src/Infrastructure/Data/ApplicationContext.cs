using Domain.Groups;
using Domain.Messages;
using Domain.Users;
using Infrastructure.Data.Domain.Groups;
using Infrastructure.Data.Domain.Messages;
using Infrastructure.Data.Domain.Outbox;
using Infrastructure.Data.Domain.Users;
using Infrastructure.DomainEventsDispatching;
using Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    internal class ApplicationContext : DbContext
    {
        internal ApplicationContext(DbContextOptions options) : 
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxEntityTypeConfiguration());
        }
    }
}
