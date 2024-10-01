using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace domaren.realestate.API.Auth;
public static class RealestateAuthOptions
{
    public const string ISSUER = "RealestateAuthServer"; 
    public const string AUDIENCE = "RealestateAuthClient"; 
    const string KEY = "RealEstateSecretKey!159Domaren=!";  
    public const int LIFETIME_IN_MINUTES = 1;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}

