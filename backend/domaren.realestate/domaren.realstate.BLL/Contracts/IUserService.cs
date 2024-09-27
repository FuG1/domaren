using domaren.realstate.BLL.Models;

namespace domaren.realstate.BLL.Contracts
{
    public interface IUserService
    {
        public User? GetUser(int id);
        public int SaveUser(User user);

    }
}
