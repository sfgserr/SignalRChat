
namespace Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task Add(T entity);

        Task<List<T>> GetAll();
    }
}
