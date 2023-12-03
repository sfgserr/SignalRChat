
namespace Domain
{
    interface IMessageRepository
    {
        Task Add(Message message);

        Task Update(Message message);

        Task GetMessages(string senderId, string receiverId);

        Task Delete(Message message);
    }
}
