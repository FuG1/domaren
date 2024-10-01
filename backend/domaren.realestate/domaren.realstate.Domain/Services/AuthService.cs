using domaren.realstate.Domain.Contracts;
using domaren.realstate.Domain.Repositories.Contarcts;
using System.Security.Claims;

namespace domaren.realstate.Domain.Services;
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashProvider _passwordHashProvider;

    public AuthService(IUserRepository userRepository, IPasswordHashProvider passwordHashProvider)
    {
        _userRepository = userRepository;
        _passwordHashProvider = passwordHashProvider;
    }

    public ClaimsIdentity AuthUser(string username, string password)
    {
        var user = _userRepository.GetUserByLogin(username);
        if (user == null)
            throw new Exception("User not exists");

        if (_passwordHashProvider.DecryptPassword(user.PasswordHash, password))
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };
            return new ClaimsIdentity(claims, "Token");
        }

        return null;
    }
}
