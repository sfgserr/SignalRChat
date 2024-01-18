using Domain.ValueObjects;

namespace Domain
{
    public interface IMessageRepository
    {
        Task Add(Message message);

        Message Update(Message message);

        Task<IList<Message>> GetMessages();

        Task<Message> GetMessage(MessageId messageId);

        Task Delete(MessageId messageId);
    }
}
