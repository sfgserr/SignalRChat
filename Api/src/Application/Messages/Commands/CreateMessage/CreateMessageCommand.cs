using Application.Cqrs.Commands;

namespace Application.Messages.Commands.CreateMessage
{
    public sealed class CreateMessageCommand(Guid toGroupId, string body, int type) : ICommand
    {
        public Guid ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public int Type { get; } = type;
    }
}
