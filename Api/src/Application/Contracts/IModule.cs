using Application.Cqrs.Commands;
using Application.Cqrs.Queries;

namespace Application.Contracts
{
    public interface IModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery query);
    }
}
