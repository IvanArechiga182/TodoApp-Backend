using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoApp.Application.Security;

namespace TodoApp.Application
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<JwtProvider>();

            return services;
        }
    }
}
