using Application.Cqrs.Commands;
using Application.Cqrs.Queries;

namespace Application.Contracts
{
    public interface IAppModule
    {
        Task ExecuteCommand<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> ExecuteCommand<TCommand, TResult>(TCommand command) where TCommand : ICommandWithResult<TResult>;

        Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
