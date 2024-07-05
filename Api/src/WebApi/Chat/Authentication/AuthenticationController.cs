using Application.Contracts;
using Application.Cqrs.Commands;
using Application.Users.Commands.Authenticate;
using Application.Users.Commands.Register;
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
        private readonly IAppModule _appModule;

        public AuthenticationController(JwtProvider jwtProvider, IAppModule appModule)
        {
            _jwtProvider = jwtProvider;
            _appModule = appModule;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            AuthenticationResult result = await _appModule.ExecuteCommand<AuthenticateCommand, AuthenticationResult>(
                new AuthenticateCommand(login, password));

            if (result.IsAuthenticated)
                return Ok(_jwtProvider.GenerateToken(result.User!.Claims));

            return Unauthorized(result.Error);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _appModule.ExecuteCommand(new RegisterCommand(
                request.Login,
                request.Password,
                request.IconUri));

            return Ok();
        }
    }
}
