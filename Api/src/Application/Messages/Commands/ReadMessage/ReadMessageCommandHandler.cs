using Domain.Messages;

namespace Application.Messages.Commands.ReadMessage
{
    public sealed class ReadMessageCommandHandler(IMessageRepository messageRepository) : IReadMessageCommandHandler
    {
        private readonly IMessageRepository _messageRepository = messageRepository;

        public async Task Handle(ReadMessageCommand command)
        {
            Message message = await _messageRepository.Get(new MessageId(command.MessageId));

            message.Read();
        }
    }
}
