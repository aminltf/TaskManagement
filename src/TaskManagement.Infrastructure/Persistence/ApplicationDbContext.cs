using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Shared.Abstractions;
using TaskManagement.Shared.Base;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskAuditLog> TaskAuditLogs { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<FileAttachment> FileAttachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Fluent API Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Soft Delete Query Filter
        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
        //    {
        //        var parameter = Expression.Parameter(entityType.ClrType, "e");
        //        var prop = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
        //        var filter = Expression.Lambda(
        //            Expression.Equal(prop, Expression.Constant(false)),
        //            parameter
        //        );
        //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        //    }
        //}

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<AuditableEntity<Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = now;
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
