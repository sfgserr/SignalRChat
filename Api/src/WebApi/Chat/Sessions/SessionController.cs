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
        [HttpPut("{index:int}")]
        public async Task<IActionResult> PlaceMark(int index)
        {
            await appModule.ExecuteCommand(new PlaceMarkCommand(index));

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
