using Application.Contracts;
using Application.Messages.Commands.CreateMessage;
using Application.Messages.Commands.EditMessage;
using Application.Messages.Commands.ReadMessage;
using Application.Messages.Queries.GetMessages;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Messages
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController(IAppModule appModule) : Controller
    {
        [HasPermission(AppPermissions.CreateMessage)]
        [HttpPost("")]
        public async Task<IActionResult> CreateMessage(CreateMessageRequest request)
        {
            await appModule.ExecuteCommand(new CreateMessageCommand(
                request.ToGroupId,
                request.Body,
                request.Type));

            return Ok();
        }

        [HasPermission(AppPermissions.ReadMessage)]
        [HttpPut("{messageId:guid}")]
        public async Task<IActionResult> ReadMessage(Guid messageId)
        {
            await appModule.ExecuteCommand(new ReadMessageCommand(messageId));

            return Ok();
        }

        [HasPermission(AppPermissions.EditMessage)]
        [HttpPut("{messageId:guid}/{body}")]
        public async Task<IActionResult> EditMessage(Guid messageId, string body)
        {
            await appModule.ExecuteCommand(new EditMessageCommand(messageId, body));

            return Ok();
        }

        [HasPermission(AppPermissions.GetMessages)]
        [HttpGet("{groupId:guid}")]
        public async Task<IActionResult> GetMessages(Guid groupId)
        {
            var messages = await appModule.Query<GetMessagesQuery, IList<GetMessageDto>>(new GetMessagesQuery(groupId));

            return Ok(messages);
        }
    }
}
