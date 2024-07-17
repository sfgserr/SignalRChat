using Application.Cqrs.Commands;

namespace Infrastructure.DomainEventsDispatching.MediatR.Handlers.Abstractions
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(InternalCommandBase command);
    }
}
