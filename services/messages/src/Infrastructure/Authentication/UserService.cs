using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Authentication
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;

            string id = user.FindFirst("sub")?.Value!;
            return id;
        }
    }
}
