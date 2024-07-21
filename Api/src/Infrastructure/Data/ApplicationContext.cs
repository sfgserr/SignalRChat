using Domain.Groups;
using Domain.Messages;
using Domain.SessionProposals;
using Domain.Sessions;
using Domain.Users;
using Infrastructure.Data.Domain.Groups;
using Infrastructure.Data.Domain.Messages;
using Infrastructure.Data.Domain.SessionProposals;
using Infrastructure.Data.Domain.Sessions;
using Infrastructure.Data.Domain.Users;
using Infrastructure.InternalCommands;
using Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionProposal> SessionProposals { get; set; }

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
            modelBuilder.ApplyConfiguration(new SessionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SessionProposalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }
    }
}
