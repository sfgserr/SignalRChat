using Application.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Configuration.Messaging
{
    public class MessageSender(IHubContext<ChatHub> chatHub) : ISender
    {
        private readonly IHubContext<ChatHub> _chatHub = chatHub;

        public async Task Send(SendMessageDto message)
        {
            await _chatHub.Clients.Group(message.ToGroupId.Value.ToString()).SendAsync("OnReceive", message);
        }
    }
}
