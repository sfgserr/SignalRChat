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
    internal class ApplicationContext(DbContextOptions options, DomainEventsDispatcher domainEventsDispatcher) : 
        DbContext(options), IUnitOfWork
    {
        private readonly DomainEventsDispatcher _domainEventsDispatcher = domainEventsDispatcher;

        private IDbContextTransaction? _currentTransaction;

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxEntityTypeConfiguration());
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        public async Task SaveChangesAsync(IDbContextTransaction transaction)
        {
            _domainEventsDispatcher.DispatchDomainEvents();

            await CommitAsync(transaction);
        }

        private async Task CommitAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentException("Transaction is null");
            if (transaction != _currentTransaction) throw new InvalidOperationException("Transaction is not current");

            try
            {
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
