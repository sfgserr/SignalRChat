using Application.Cqrs.Commands;

namespace Application.Messages.Commands.EditMessage
{
    public sealed class EditMessageCommand(Guid messageId, string body) : ICommand
    {
        public Guid MessageId { get; } = messageId;

        public string Body { get; } = body;
    }
}
