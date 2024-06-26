﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authorization
{
    internal class JwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        internal JwtProvider(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateToken(List<Claim> claims)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _jwtOptions.IssuerUrl,
                _jwtOptions.AudienceUrl,
                claims,
                null,
                DateTime.UtcNow.AddDays(1),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
