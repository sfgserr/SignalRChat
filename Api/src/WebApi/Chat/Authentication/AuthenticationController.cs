using Application.Cqrs.Commands;
using Application.Users.Commands.Authenticate;
using Autofac;
using Infrastructure.Authorization;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Authentication
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly JwtProvider _jwtProvider;

        public AuthenticationController(JwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            using var scope = AppCompositionRoot.BeginLifetimeScope();

            var handler = scope.Resolve<ICommandHandlerWithResult<AuthenticateCommand, AuthenticationResult>>();

            var result = await handler.Handle(new(login, password));

            if (result.IsAuthenticated)
            {
                return Ok(_jwtProvider.GenerateToken(result.User!.Claims));
            }

            return Unauthorized(result.Error);
        }
    }
}
