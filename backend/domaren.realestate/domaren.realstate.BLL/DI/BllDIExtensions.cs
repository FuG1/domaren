using domaren.realstate.BLL.Contracts;
using domaren.realstate.BLL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace domaren.realstate.BLL.DI
{
    public static class BllDIExtensions
    {
        public static IServiceCollection AddBllModules(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
