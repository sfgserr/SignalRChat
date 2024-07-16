using Application.Cqrs.Commands;
using Domain.Messages;

namespace Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand(Guid toGroupId, string body, MessageType type) : ICommand
    {
        public Guid ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public MessageType Type { get; } = type;
    }
}
