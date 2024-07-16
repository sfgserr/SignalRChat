using Application.Cqrs.Commands;

namespace Application.Messages.Commands.EditMessage
{
    public class EditMessageCommand(Guid messageId, string body) : ICommand
    {
        public Guid MessageId { get; } = messageId;

        public string Body { get; } = body;
    }
}
