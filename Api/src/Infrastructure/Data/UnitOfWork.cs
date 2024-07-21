using Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DomainEventsDispatcher _domainEventsDispatcher;
        private readonly ApplicationContext _applicationContext;

        private IDbContextTransaction? _currentTransaction;

        internal UnitOfWork(DomainEventsDispatcher domainEventsDispatcher, ApplicationContext applicationContext)
        {
            _domainEventsDispatcher = domainEventsDispatcher;
            _applicationContext = applicationContext;
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await _applicationContext.Database.BeginTransactionAsync();

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
                await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                transaction.Rollback();
                throw;
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
