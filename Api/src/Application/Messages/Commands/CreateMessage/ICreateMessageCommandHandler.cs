using Application.Cqrs.Commands;

namespace Application.Messages.Commands.CreateMessage
{
    public interface ICreateMessageCommandHandler : ICommandHandler<CreateMessageCommand>
    {
    }
}
