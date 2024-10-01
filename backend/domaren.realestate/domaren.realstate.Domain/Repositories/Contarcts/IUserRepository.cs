using domaren.realstate.Domain.Repositories.Models;

namespace domaren.realstate.Domain.Repositories.Contarcts
{
    public interface IUserRepository
    {
        public UserRecord? GetUser(int id);
        public int SaveUser(UserRecord user);
    }
}
