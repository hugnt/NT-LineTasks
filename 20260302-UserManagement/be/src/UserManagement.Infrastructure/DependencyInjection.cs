using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Abstractions;
using UserManagement.Infrastructure.Persistence;
using UserManagement.Infrastructure.Persistence.Interceptors;
using UserManagement.Infrastructure.Persistence.Repository;

namespace UserManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        //db
        services.AddScoped<AuditableEntityInterceptor>();
        services.AddDbContext<AppDbContext>((sp,options) =>
        {
            options.UseInMemoryDatabase(databaseName:"Persondb");
            options.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
        });

        //Unit of work
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

        //Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
