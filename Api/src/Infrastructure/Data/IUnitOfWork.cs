using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    public interface IUnitOfWork
    {
        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task SaveChangesAsync(IDbContextTransaction transaction);
    }
}
