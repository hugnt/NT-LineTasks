using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Services;
using UserManagement.Application.Services.Implement;

namespace UserManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Services
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
