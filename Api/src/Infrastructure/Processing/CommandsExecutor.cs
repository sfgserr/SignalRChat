using Application.Cqrs.Commands;
using Autofac;
using Infrastructure.Configuration;

namespace Infrastructure.Processing
{
    internal static class CommandsExecutor
    {
        internal async static Task ExecuteCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));

            var handler = scope.Resolve(handlerType) as ICommandHandler<TCommand>;

            await handler!.Handle(command);
            return;
        }

        internal async static Task<TResult> ExecuteCommandAsync<TCommand, TResult>(TCommand command) 
            where TCommand : ICommandWithResult<TResult>
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            Type handlerType = typeof(ICommandHandlerWithResult<,>).MakeGenericType(typeof(TCommand), typeof(TResult));

            var handler = scope.Resolve(handlerType) as ICommandHandlerWithResult<TCommand, TResult>;

            return await handler!.Handle(command);
        }
    }
}
