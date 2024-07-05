using Application.Contracts;

namespace WebApi.Configuration.Authentication
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            string? id = _httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value;

            if (id is not null)
            {
                bool isParsed = Guid.TryParse(id, out Guid guid);

                if (isParsed)
                    return guid;

                throw new ArgumentException("User id is not guid");
            }

            throw new ApplicationException("User context in unavailable");
        }
    }
}
