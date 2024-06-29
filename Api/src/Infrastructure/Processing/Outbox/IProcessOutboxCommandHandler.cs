using Application.Cqrs.Commands;

namespace Infrastructure.Processing.Outbox
{
    internal interface IProcessOutboxCommandHandler : ICommandHandler<ProcessOutboxCommand>
    {

    }
}
