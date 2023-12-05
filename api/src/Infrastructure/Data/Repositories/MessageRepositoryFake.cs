using Domain;
using Domain.ValueObjects;

namespace Infrastructure.Data.Repositories
{
    public class MessageRepositoryFake : IMessageRepository
    {
        private readonly ChatContextFake _context;

        public MessageRepositoryFake(ChatContextFake context)
        {
            _context = context;
        }

        public async Task Add(Message message)
        {
            _context.Messages.Add(message);

            await Task.CompletedTask;
        }

        public async Task Delete(MessageId messageId)
        {
            Message message = _context.Messages.FirstOrDefault(m => m.Id == messageId);

            if (message != null)
                _context.Messages.Remove(message);

            await Task.CompletedTask;
        }

        public async Task<IList<Message>> GetMessages(string senderId, string receiverId)
        {
            List<Message> messages = _context.Messages;

            return await Task.FromResult(messages);
        }

        public void Update(Message message)
        {
            Message messageToUpdate = _context.Messages.FirstOrDefault(m => m.Id == message.Id);

            if (messageToUpdate != null)
                _context.Messages.Remove(message);

            _context.Messages.Add(message);
        }
    }
}
