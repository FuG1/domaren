using domaren.realstate.BLL.Repositories.Contarcts;
using domaren.realstate.DAL.EF;
using domaren.realstate.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace domaren.realstate.DAL.DI
{
    public static class DalDIModules
    {
        public static IServiceCollection AddDalModules(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddPostgresDb();

            return services;
        }

        public static IServiceCollection AddPostgresDb(this IServiceCollection services) 
        {
            services.AddDbContext<RealEstateDBContext>();

            return services;
        }
    }
}
