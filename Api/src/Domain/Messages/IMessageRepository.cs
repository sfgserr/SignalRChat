using Domain.Groups;
using Domain.SeedWork;

namespace Domain.Messages
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> Get(MessageId messageId);

        Task<IList<Message>> Get(GroupId groupId);
    }
}
