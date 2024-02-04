using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AspnetClient.Controllers
{
    [Route("Account")]
    public class LoginController : Controller
    {
        [HttpGet("Login")]
        public async Task Login(string redirectUrl)
        {
            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action(nameof(LoginCallBack), "Login", new { redirectUrl })
            });
        }

        public async Task LoginCallBack(string redirectUrl)
        {
            var auth = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);

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

            HttpContext.Response.Redirect("https://chat.local/signin-oidc");
        }
    }
}
