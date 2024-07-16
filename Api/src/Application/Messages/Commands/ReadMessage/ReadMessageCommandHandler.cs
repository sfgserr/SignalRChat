using Application.Cqrs.Commands;
using Domain.Messages;

namespace Application.Messages.Commands.ReadMessage
{
    internal class ReadMessageCommandHandler : ICommandHandler<ReadMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;

        internal ReadMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task Handle(ReadMessageCommand command)
        {
            Message message = await _messageRepository.Get(new MessageId(command.MessageId));

            message.Read();
        }
    }
}
