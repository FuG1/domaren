using domaren.realstate.Domain.Repositories.Contarcts;
using domaren.realstate.Infrastructure.EF;
using domaren.realstate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace domaren.realstate.Infrastructure.DI
{
    public static class DalDIModules
    {
        public static IServiceCollection AddDalModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddPostgresDb(configuration);

            return services;
        }

        public static IServiceCollection AddPostgresDb(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<RealEstateDBContext>(x => x.UseNpgsql(configuration.GetConnectionString("RealEstateDbConnectionString")));

            return services;
        }
    }
}
