using Application.Contracts;
using Application.Groups.Commands.CreateGroup;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Groups
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController(IAppModule appModule) : Controller
    {
        private readonly IAppModule _appModule = appModule;

        [HasPermission(AppPermissions.CreateGroup)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateGroupRequest request)
        {
            await _appModule.ExecuteCommand(new CreateGroupCommand(
                request.Name,
                request.IconUri));

            return Ok();
        }
    }
}
