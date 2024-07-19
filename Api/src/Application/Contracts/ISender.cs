using Application.SessionProposals;
using Domain.Groups;
using Domain.Messages;
using Domain.Sessions;
using Domain.Users;

namespace Application.Contracts
{
    public interface ISender
    {
        Task Send(SendMessageDto message);

        Task Send(SessionProposalDto sessionProposal);

        Task Send(string message, UserId userId);

        Task Send(SessionId sessionId, UserId crossUserId, UserId noughtUserId);

        Task Send(UserId user, char mark);
    }

    public class SendMessageDto(UserId senderId, GroupId toGroupId, string body, MessageType messageType)
    {
        public UserId SenderId { get; } = senderId;

        public GroupId ToGroupId { get; } = toGroupId;

        public string Body { get; } = body;

        public MessageType MessageType { get; } = messageType;
    }
}
