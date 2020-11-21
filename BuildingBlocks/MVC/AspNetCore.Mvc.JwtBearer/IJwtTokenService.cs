using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AspNetCore.Mvc.JwtBearer
{
    public interface IJwtTokenService
    {
        JwtToken GenerateToken<TKey>(
           UserIdentity<TKey> userIdentity,
           IEnumerable<string> roles = null,
           IEnumerable<Claim> additionClaims = null,
           string issuer = null,
           string audience = null);
    }
}
