using Application.Contracts;
using Application.Messages.Commands.CreateMessage;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Messages
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController(IAppModule appModule) : Controller
    {
        private readonly IAppModule _appModule = appModule;

        [HasPermission(AppPermissions.CreateMessage)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateMessage(CreateMessageRequest request)
        {
            await _appModule.ExecuteCommand(new CreateMessageCommand(
                request.ToGroupId,
                request.Body,
                request.Type));

            return Ok();
        }
    }
}
