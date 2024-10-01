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

        public int SaveUser(UserRecord user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }
    }
}
