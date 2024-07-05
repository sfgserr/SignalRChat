using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Autofac;
using Infrastructure.Configuration;

namespace Infrastructure.Processing
{
    internal static class CommandsExecutor
    {
        public async static Task ExecuteCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));

            var handler = scope.Resolve(handlerType) as ICommandHandler<TCommand>;

            if (handler is not null)
            {
                await handler.Handle(command);
                return;
            }

            throw new ArgumentException($"Can't resolve handler for {command.GetType().Name}");
        }

        public async static Task<TResult> ExecuteCommandAsync<TCommand, TResult>(TCommand command) 
            where TCommand : ICommandWithResult<TResult>
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            Type handlerType = typeof(ICommandHandlerWithResult<,>).MakeGenericType(typeof(TCommand), typeof(TResult));

            var handler = scope.Resolve(handlerType) as ICommandHandlerWithResult<TCommand, TResult>;

            if (handler is not null)
                return await handler.Handle(command);

            throw new ArgumentException($"Can't resolve handler for {command.GetType().Name}");
        }

        public async static Task<TResult> QueryAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            Type? handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeof(TQuery), typeof(TResult));

            var handler = scope.Resolve(handlerType) as IQueryHandler<TQuery, TResult>;

            if (handler is not null)
                return await handler.Handle(query);

            throw new ArgumentException($"Can't resolve handler {query.GetType().Name}");
        }
    }
}
