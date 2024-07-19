using Application.Contracts;
using Application.SessionProposals;
using Application.SessionProposals.Commands.AcceptProposal;
using Application.SessionProposals.Commands.Propose;
using Application.SessionProposals.Queries.GetUserSessionProposals;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.SessionProposals
{
    [ApiController]
    [Route("api/sessionProposals")]
    public class SessionProposalController(IAppModule appModule) : Controller
    {
        [HasPermission(AppPermissions.Propose)]
        [HttpPost("propose")]
        public async Task<IActionResult> Propose(Guid groupId, Guid toUserId)
        {
            await appModule.ExecuteCommand(new ProposeCommand(groupId, toUserId));

            return Ok();
        }

        [HasPermission(AppPermissions.AcceptProposal)]
        [HttpPut("{sessionProposalId:guid}")]
        public async Task<IActionResult> AcceptProposal(Guid sessionProposalId)
        {
            await appModule.ExecuteCommand(new AcceptProposalCommand(sessionProposalId));

            return Ok();
        }

        [HasPermission(AppPermissions.AcceptProposal)]
        [HttpGet("")]
        public async Task<IActionResult> GetUserSessionProposals()
        {
            var proposals = await appModule
                .Query<GetUserSessionProposalsQuery, IList<SessionProposalDto>>(new GetUserSessionProposalsQuery());

            return Ok(proposals);
        }
    }
}
