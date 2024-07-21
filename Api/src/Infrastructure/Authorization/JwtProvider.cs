using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authorization
{
    public class JwtProvider(JwtOptions jwtOptions)
    {
        public string GenerateToken(List<Claim> claims)
        {
            claims.Add(new("Permission", "CreateGroup"));

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                jwtOptions.IssuerUrl,
                jwtOptions.AudienceUrl,
                claims,
                null,
                DateTime.UtcNow.AddDays(1),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
