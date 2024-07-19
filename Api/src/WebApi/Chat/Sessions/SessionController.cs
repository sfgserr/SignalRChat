using Application.Contracts;
using Application.Sessions.Commands.PlaceMark;
using Application.Sessions.Queries.GetSession;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Sessions
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController(IAppModule appModule) : Controller
    {
        [HasPermission(AppPermissions.PlaceMark)]
        [HttpPut("{sessionId:guid}/{index:int}/{mark}")]
        public async Task<IActionResult> PlaceMark(Guid sessionId, int index, char mark)
        {
            await appModule.ExecuteCommand(new PlaceMarkCommand(sessionId, index, mark));

            return Ok();
        }

        [HasPermission(AppPermissions.GetSession)]
        [HttpGet("")]
        public async Task<IActionResult> GetSession()
        {
            var session = await appModule.Query<GetSessionQuery, SessionDto>(new GetSessionQuery());

            return Ok(session);
        }
    }
}
