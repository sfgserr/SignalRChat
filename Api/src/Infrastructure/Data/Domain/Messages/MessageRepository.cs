using Domain.Groups;
using Domain.Messages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppContext _appContext;

        public MessageRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task Add(Message entity)
        {
            await _appContext.Messages.AddAsync(entity);
        }

        public async Task<Message> Get(MessageId messageId)
        {
            return await _appContext.Messages.FindAsync(messageId);
        }

        public async Task<IList<Message>> Get(GroupId groupId)
        {
            return await _appContext.Messages.Where(m => m.ToGroupId == groupId).ToListAsync();
        }

        public async Task<List<Message>> GetAll()
        {
            return await _appContext.Messages.ToListAsync();
        }

        public void Update(Message entity)
        {
            _appContext.Messages.Update(entity);
        }
    }
}
