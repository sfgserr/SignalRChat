using Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Authentication
{ 
   internal class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        internal UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            string id = _httpContextAccessor.HttpContext.User.FindFirst("id")!.Value;

            return new Guid(id);
        }
    }
}
