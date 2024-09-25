using domaren.realstate.BLL.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace domaren.realstate.DAL.EF
{
    public class RealEstateDBContext : DbContext
    { 
        public DbSet<UserRecord> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("server=localhost;port=5432;userid=postgres;password=admin;database=realestate;enlist=true;");      
    }
}
