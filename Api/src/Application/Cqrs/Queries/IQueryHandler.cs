
namespace Application.Cqrs.Queries
{
    public interface IQueryHandler<T, TResult> where T : IQuery
    {
        Task<TResult> Handle(T query);
    }
}
