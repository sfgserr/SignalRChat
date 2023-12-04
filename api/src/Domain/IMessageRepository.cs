using Domain.ValueObjects;

namespace Domain
{
    public interface IMessageRepository
    {
        Task Add(Message message);

        void Update(Message message);

        Task<IList<Message>> GetMessages(string senderId, string receiverId);

        Task Delete(MessageId messageId);
    }
}
