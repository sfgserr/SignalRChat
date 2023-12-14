using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace Client.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("Login")]
        public async Task Login()
        {
            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action(nameof(LoginCallBack), "Auth", new { OpenIdConnectDefaults.AuthenticationScheme })
            });
        }

        public async Task LoginCallBack(string scheme)
        {
            var auth = await HttpContext.AuthenticateAsync(scheme);

            var claims = auth.Principal.Identities.FirstOrDefault()?.Claims;
            var userId = string.Empty;
            userId = claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var qs = new Dictionary<string, string>
            {
                { "access_token", auth.Properties.GetTokenValue("access_token") },
                { "refresh_token", auth.Properties.GetTokenValue("refresh_token") ?? string.Empty },
                { "expires_in", (auth.Properties.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToString() },
                { "user_id", userId }
            };

            string userAgent = Request.Headers[HeaderNames.UserAgent].ToString();

            HttpContext.Response.Redirect("/");
        }
    }
}
