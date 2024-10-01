using domaren.realstate.Domain.Models;

namespace domaren.realstate.Domain.Contracts
{
    public interface IUserService
    {
        public User? GetUser(int id);
        public int SaveUser(User user);

    }
}
