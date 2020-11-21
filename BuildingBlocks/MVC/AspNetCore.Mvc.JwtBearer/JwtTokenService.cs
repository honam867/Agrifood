using AspNetCore.Common.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCore.Mvc.JwtBearer
{
    public class JwtTokenService : IJwtTokenService
    {
        private JwtTokenOptions _options;
        public JwtTokenService(JwtTokenOptions options)
        {
            _options = options;
        }
        public JwtToken GenerateToken<TKey>(
            UserIdentity<TKey> userIdentity,
            IEnumerable<string> roles = null,
            IEnumerable<Claim> additionClaims = null,
            string issuer = null,
            string audience = null)
        {
            var userIdInString = userIdentity.Id.ToString();
            var timeout = TimeSpan.FromMinutes(_options.TokenTimeOutMinutes);
            var issueDate = DateTime.UtcNow;
            var expiredDate = issueDate.Add(timeout);

            var claims = new List<Claim>();
            if (additionClaims != null)
            {
                claims.AddRange(additionClaims);
            }
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            claims.Add(new Claim(ClaimTypes.Name, userIdentity.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userIdInString));

            var sigingCredential = new SigningCredentials(_options.SecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtPayload = new JwtPayload(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: null,
                expires: expiredDate,
                issuedAt: issueDate
                );
            var jwtHeader = new JwtHeader(sigingCredential);
            var jwtToken = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtToken
            {
                Access_token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expires_in = timeout.TotalSeconds,
                Expires_date = expiredDate,
                Issue_date = issueDate,
                Token_type = "Bearer"
            };
        }
    }
}
