using Application.Contracts;
using Application.Sessions.Commands.PlaceMark;
using Application.Sessions.Queries.GetSession;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Sessions
{
    [ApiController]
    [Route("api/session")]
    public class SessionController(IAppModule appModule) : Controller
    {
        [HasPermission(AppPermissions.PlaceMark)]
        [HttpPut("{index:int}/{mark}")]
        public async Task<IActionResult> PlaceMark(int index, char mark)
        {
            await appModule.ExecuteCommand(new PlaceMarkCommand(index, mark));

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
