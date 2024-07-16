using Domain.Groups;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Queries.GetMessages
{
    public class MessageDto(Message message)
    {
        public MessageId Id { get; } = message.Id;

        public UserId SenderId { get; } = message.SenderId;

        public GroupId ToGroupId { get; } = message.ToGroupId;

        public string Body { get; } = message.Body;

        public MessageType Type { get; } = message.Type;

        public DateTime CreationTime { get; } = message.CreationTime;

        public bool IsEditted { get; } = message.IsEditted;

        public bool IsRead { get; } = message.IsRead;
    }
}
