using domaren.realstate.Domain.Repositories.Contarcts;
using domaren.realstate.Domain.Repositories.Models;
using domaren.realstate.Infrastructure.EF;

namespace domaren.realstate.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealEstateDBContext _dbContext;

        public UserRepository(RealEstateDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRecord? GetUser(int id)
        {
            return _dbContext.Users
                .FirstOrDefault(x => x.Id == id);
        }

        public UserRecord? GetUserByLogin(string userLogin)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Login == userLogin);
        }

        public bool IsUserExists(string userLogin)
        {
            return _dbContext.Users.Any(x => x.Login == userLogin);
        }

        public int SaveUser(UserRecord user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }
    }
}
