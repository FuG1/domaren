using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace domaren.realestate.API.Auth;

public class JwtTokenProvider
{
    public static string GetToken(ClaimsIdentity identity)
    {
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: RealestateAuthOptions.ISSUER,
            audience: RealestateAuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(RealestateAuthOptions.LIFETIME_IN_MINUTES)),
            signingCredentials: new SigningCredentials(RealestateAuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}
