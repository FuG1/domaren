using domaren.realstate.Domain.Contracts;
using domaren.realstate.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace domaren.realstate.Domain.DI
{
    public static class BllDIExtensions
    {
        public static IServiceCollection AddBllModules(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IPasswordHashProvider, PasswordHashProvider>();

            return services;
        }
    }
}
