using Domain.Groups;
using Domain.Messages;
using Domain.Users;
using Infrastructure.Data.Domain.Groups;
using Infrastructure.Data.Domain.InternalCommands;
using Infrastructure.Data.Domain.Messages;
using Infrastructure.Data.Domain.Outbox;
using Infrastructure.Data.Domain.Users;
using Infrastructure.InternalCommands;
using Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : 
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserPermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserRolePermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }
    }
}
