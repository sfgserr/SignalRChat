using Application.Contracts;
using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Infrastructure.Processing;

namespace Infrastructure
{
    public class AppModule : IAppModule
    {
        public async Task ExecuteCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            await CommandsExecutor.ExecuteCommandAsync(command);
        }

        public async Task<TResult> ExecuteCommand<TCommand, TResult>(TCommand command) where TCommand : ICommandWithResult<TResult>
        {
            return await CommandsExecutor.ExecuteCommandAsync<TCommand, TResult>(command);
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            return await CommandsExecutor.QueryAsync<TQuery, TResult>(query);
        }
    }
}
