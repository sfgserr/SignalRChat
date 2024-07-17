using Domain.Groups;
using Domain.Messages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Messages
{
    internal class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal MessageRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(Message entity)
        {
            await _applicationContext.Messages.AddAsync(entity);
        }

        public async Task<Message> Get(MessageId messageId)
        {
            return await _applicationContext.Messages.FindAsync(messageId);
        }

        public async Task<IList<Message>> Get(GroupId groupId)
        {
            return await _applicationContext.Messages.Where(m => m.ToGroupId == groupId).ToListAsync();
        }

        public async Task<List<Message>> GetAll()
        {
            return await _applicationContext.Messages.ToListAsync();
        }
    }
}
