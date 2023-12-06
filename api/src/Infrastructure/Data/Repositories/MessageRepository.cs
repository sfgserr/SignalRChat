using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _context;

        public MessageRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task Add(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public Message Update(Message message)
        {
            _context.Messages.Update(message);

            return message;
        }

        public async Task<IList<Message>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetMessage(MessageId messageId)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
        }

        public async Task Delete(MessageId messageId)
        {
            await _context
                  .Database
                  .ExecuteSqlRawAsync("DELETE FROM Messages WHERE Id=@p0", messageId.Id);
        }
    }
}
