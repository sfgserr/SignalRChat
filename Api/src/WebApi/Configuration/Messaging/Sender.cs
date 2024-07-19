using Application.Contracts;
using Application.SessionProposals;
using Domain.Sessions;
using Domain.Users;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Configuration.Messaging
{
    public class Sender(IHubContext<ChatHub> chatHub) : ISender
    {
        private readonly IHubContext<ChatHub> _chatHub = chatHub;

        public async Task Send(SendMessageDto message)
        {
            await _chatHub.Clients.Group(message.ToGroupId.Value.ToString()).SendAsync("OnReceive", message);
        }

        public async Task Send(SessionProposalDto proposal)
        {
            await Send(proposal.ProposedUserId, "OnReceiveProposal", proposal);
        }

        public async Task Send(string message, UserId userId)
        {
            await Send(userId.Value, "OnSessionEnded", message);
        }

        public async Task Send(SessionId sessionId, UserId crossUserId, UserId noughtUserId)
        {
            string message = $"Session:{sessionId.Value}";

            await Send(crossUserId.Value, "OnSessionCreated", message);
            await Send(noughtUserId.Value, "OnSessionCreated", message);
        }

        public async Task Send(UserId userId, char mark)
        {
            await Send(userId.Value, "OnMarkPlaced", mark);
        }

        private async Task Send<T>(Guid identityId, string method, T data)
        {
            var connections = ConnectionMapper.GetConnections(identityId);

            foreach (string connection in connections)
                await _chatHub.Clients.Client(connection).SendAsync(method, data);
        }
    }
}
