using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Helpers
{
    public static class AuthHelper
    {
        public static List<Claim> ResolveToken(this string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(token) || !tokenHandler.CanReadToken(token))
            {
                return null;
            }
            return tokenHandler.ReadJwtToken(token).Claims.ToList();
        }
    }
}
