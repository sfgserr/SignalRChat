using Domain.Groups;
using Domain.Messages;
using Domain.Users;

namespace Application.Messages.Commands.SendMessage
{
    public class MessageDto(UserId senderId, GroupId toGroupId, string body, MessageType type)
    {
        public UserId SenderId { get; } = senderId;

        public GroupId ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public MessageType Type { get; } = type;
    }
}
