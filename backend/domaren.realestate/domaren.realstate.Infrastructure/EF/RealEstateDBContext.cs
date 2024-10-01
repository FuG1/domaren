using domaren.realstate.Domain.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace domaren.realstate.Infrastructure.EF
{
    public class RealEstateDBContext : DbContext
    {
        public RealEstateDBContext(DbContextOptions options) : base(options){ }

        public DbSet<UserRecord> Users { get; set; } 
    }
}
