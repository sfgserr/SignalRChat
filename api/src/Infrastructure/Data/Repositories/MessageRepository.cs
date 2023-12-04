using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        public void Update(Message message)
        {
            _context.Messages.Update(message);
        }

        public async Task<IList<Message>> GetMessages(string senderId, string receiverId)
        {
            return await _context.Messages.Where(m => m.ExternalUserSenderId == senderId && m.ExternalUserReceiverId == senderId).ToListAsync();
        }

        public async Task Delete(MessageId messageId)
        {
            await _context
                  .Database
                  .ExecuteSqlRawAsync("DELETE FROM Messages WHERE AccountId=@p0", messageId.Id);
        }
    }
}
