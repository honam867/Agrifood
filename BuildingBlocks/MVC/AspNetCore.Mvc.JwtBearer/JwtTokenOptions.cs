using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.JwtBearer
{
    public class JwtTokenOptions
    {
        public SecurityKey SecurityKey { set; get; }
        public long TokenTimeOutMinutes { set; get; }

        public bool ValidateAudience { set; get; } = false;
        public bool ValidateIssuer { set; get; } = false;
        public bool ValidateIssuerSigningKey { set; get; } = true;
        public bool ValidateLifeTime { set; get; } = true;
    }
}
