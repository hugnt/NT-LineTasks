using System.Reflection;

using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Abstractions.Persistence;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Persistence;

public class AppDbContext : DbContext, IUnitOfWork
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public AppDbContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

     public DbSet<User> Users { get; set; }
}
