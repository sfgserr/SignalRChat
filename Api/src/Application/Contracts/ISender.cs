using Domain.Groups;
using Domain.Messages;
using Domain.Users;

namespace Application.Contracts
{
    public interface ISender
    {
        Task Send(SendMessageDto message);
    }

    public class SendMessageDto(UserId senderId, GroupId toGroupId, string body, MessageType messageType)
    {
        public UserId SenderId { get; } = senderId;

        public GroupId ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public MessageType MessageType { get; } = messageType;
    }
}
