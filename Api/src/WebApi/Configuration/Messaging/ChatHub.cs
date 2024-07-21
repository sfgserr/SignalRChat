using Application.Contracts;
using Application.Groups.Queries;
using Application.Groups.Queries.GetUserGroups;
using Domain.Users;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Configuration.Messaging
{
    [HasPermission()]
    public class ChatHub(IAppModule appModule, IUserContext userContext) : Hub
    {
        public override async Task OnConnectedAsync()
        {
            ConnectionMapper.AddConnection(userContext.Id.Value, Context.ConnectionId);

            var groups = await appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            foreach (var group in groups)
                await Groups.AddToGroupAsync(Context.ConnectionId, group.Id.ToString());
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectionMapper.RemoveConnection(userContext.Id.Value, Context.ConnectionId);

            var groups = await appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            foreach (var group in groups)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, group.Id.ToString());
        }
    }
}
