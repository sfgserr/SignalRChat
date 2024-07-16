using Application.Contracts;
using Application.Cqrs.Commands;

namespace Application.Messages.Commands.SendMessage
{
    internal class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
    {
        private readonly ISender _sender;

        internal SendMessageCommandHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task Handle(SendMessageCommand command)
        {
            await _sender.Send(new MessageDto(
                command.SenderId,
                command.ToGroupId,
                command.Body,
                command.Type));
        }
    }
}
