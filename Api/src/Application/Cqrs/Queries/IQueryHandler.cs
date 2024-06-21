
namespace Application.Cqrs.Queries
{
    public interface IQueryHandler<T, TResult> where T : IQuery<TResult>
    {
        Task<TResult> Handle(T query);
    }
}
