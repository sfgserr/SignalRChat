﻿using Application.Contracts;
using Application.Groups.Commands.AddUser;
using Application.Groups.Commands.ChangeGroupName;
using Application.Groups.Commands.ChangeIconUri;
using Application.Groups.Commands.CreateGroup;
using Application.Groups.Commands.RemoveUser;
using Application.Groups.Queries;
using Application.Groups.Queries.GetGroup;
using Application.Groups.Queries.GetUserGroups;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Groups
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController(IAppModule appModule) : Controller
    {
        [HasPermission()]
        [HttpPost("")]
        public async Task<IActionResult> Create(CreateGroupRequest request)
        {
            await appModule.ExecuteCommand(new CreateGroupCommand(
                request.Name,
                request.IconUri));

            return Ok();
        }

        [HasPermission(AppPermissions.AddUser)]
        [HttpPost("{groupId:guid}/{userId:guid}")]
        public async Task<IActionResult> AddUser(Guid groupId, Guid userId)
        {
            await appModule.ExecuteCommand(new AddUserCommand(userId, groupId));

            return Ok();
        }

        [HasPermission(AppPermissions.ChangeName)]
        [HttpPut("{groupId:guid}/{groupName}")]
        public async Task<IActionResult> ChangeGroupName(Guid groupId, string groupName)
        {
            await appModule.ExecuteCommand(new ChangeGroupNameCommand(groupId, groupName));

            return Ok();
        }

        [HasPermission(AppPermissions.ChangeIconUri)]
        [HttpPut("{groupId:guid}")]
        public async Task<IActionResult> ChangeIconUri(Guid groupId, [FromQuery] string iconUri)
        {
            await appModule.ExecuteCommand(new ChangeIconUriCommand(groupId, iconUri));

            return Ok();
        }

        [HasPermission(AppPermissions.RemoveUser)]
        [HttpDelete("{groupId:guid}/{userId}")]
        public async Task<IActionResult> RemoveUser(Guid userId, Guid groupId)
        {
            await appModule.ExecuteCommand(new RemoveUserCommand(userId, groupId));

            return Ok();
        }

        [HasPermission(AppPermissions.GetGroup)]
        [HttpGet("{groupId:guid}")]
        public async Task<IActionResult> GetGroup(Guid groupId)
        {
            var group = await appModule.Query<GetGroupQuery, GroupDto>(new GetGroupQuery(groupId));

            return Ok(group);
        }

        [HasPermission(AppPermissions.GetUserGroups)]
        [HttpGet("")]
        public async Task<IActionResult> GetUserGroups()
        {
            var groups = await appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            return Ok(groups);
        }
    }
}
