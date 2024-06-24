using Application.Cqrs.Commands;

namespace Application.Messages.Commands.ReadMessage
{
    public interface IReadMessageCommandHandler : ICommandHandler<ReadMessageCommand>
    {   
    }
}
