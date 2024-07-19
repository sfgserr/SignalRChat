using Application.Contracts;
using Application.Users.Commands.Authenticate;
using Application.Users.Commands.Register;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Chat.Authentication
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController(JwtProvider jwtProvider, IAppModule appModule) : Controller
    {
        private readonly JwtProvider _jwtProvider = jwtProvider;
        private readonly IAppModule _appModule = appModule;

        [HttpPost("login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            AuthenticationResult result = await _appModule.ExecuteCommand<AuthenticateCommand, AuthenticationResult>(
                new AuthenticateCommand(login, password));

            if (result.IsAuthenticated)
                return Ok(_jwtProvider.GenerateToken(result.User!.Claims));

            return Unauthorized(result.Error);
        }

        [HttpPost("register")]
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
