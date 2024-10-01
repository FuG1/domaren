using System.Security.Claims;

namespace domaren.realstate.Domain.Contracts
{
    public interface IAuthService
    {
        public ClaimsIdentity? AuthUser(string username, string password);
    }
}
