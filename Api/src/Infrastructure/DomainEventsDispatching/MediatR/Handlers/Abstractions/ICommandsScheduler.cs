using Application.Cqrs.Commands;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions
{
    internal interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}
