using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Persistence;
using UserManagement.Infrastructure.Persistence.SeedData;

namespace UserManagement.API.Extensions;

public static class DatabaseExtensions
{
    public static async Task SeedDatabaseAsync(this WebApplication app, CancellationToken cancellationToken = default)
    {
        using IServiceScope scope = app.Services.CreateScope();

        AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.EnsureCreatedAsync(cancellationToken);

        if (await dbContext.Users.AnyAsync(cancellationToken))
        {
            return;
        }

        await dbContext.Users.AddRangeAsync(UserSeed.Users, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
