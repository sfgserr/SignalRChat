using System.Security.Claims;

namespace Application.Users.Commands.Authenticate
{
    public class UserDto(List<Claim> claims)
    {
        public List<Claim> Claims { get; } = claims;
    }
}
