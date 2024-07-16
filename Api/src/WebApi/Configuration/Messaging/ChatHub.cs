using Application.Contracts;
using Application.Groups.Queries;
using Application.Groups.Queries.GetUserGroups;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Configuration.Messaging
{
    [HasPermission()]
    public class ChatHub(IAppModule appModule) : Hub
    {
        private readonly IAppModule _appModule = appModule;

        public override async Task OnConnectedAsync()
        {
            var groups = await _appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            foreach (var group in groups)
                await Groups.AddToGroupAsync(Context.ConnectionId, group.Id.ToString());
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var groups = await _appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            foreach (var group in groups)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, group.Id.ToString());
        }
    }
}
