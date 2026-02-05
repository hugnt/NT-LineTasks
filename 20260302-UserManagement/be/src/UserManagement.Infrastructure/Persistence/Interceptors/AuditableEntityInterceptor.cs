using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UserManagement.Domain.Primitives;

namespace UserManagement.Infrastructure.Persistence.Interceptors;

public class AuditableEntityInterceptor() : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        DbContext? dbContext = eventData.Context;

        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        IEnumerable<EntityEntry<IAuditableEntity>> entries =
            dbContext
                .ChangeTracker
                .Entries<IAuditableEntity>();

        foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                //entityEntry.Property(a => a.CreatedBy).CurrentValue = userContext.UserId;
                entityEntry.Property(a => a.CreatedAt).CurrentValue = DateTime.Now;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                //entityEntry.Property(a => a.UpdatedBy).CurrentValue = userContext.UserId;
                entityEntry.Property(a => a.UpdatedAt).CurrentValue = DateTime.Now;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}