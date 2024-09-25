using domaren.realstate.BLL.Repositories.Models;

namespace domaren.realstate.BLL.Repositories.Contarcts
{
    public interface IUserRepository
    {
        public UserRecord? GetUser(int id);
        public int SaveUser(UserRecord user);
    }
}
