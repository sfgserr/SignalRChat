using Domain.SeedWork;

namespace Domain.Messages
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> Get(MessageId messageId);
    }
}
