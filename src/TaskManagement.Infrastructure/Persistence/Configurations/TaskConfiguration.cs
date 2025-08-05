using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Tenant)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.TenantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Priority)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.DueDate)
            .HasConversion<DateTime>()
            .IsRequired(false);

        builder.HasOne(x => x.AssignedTo)
            .WithMany(x => x.AssignedTasks)
            .HasForeignKey(x => x.AssignedToId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Reporter)
            .WithMany(x => x.ReportedTasks)
            .HasForeignKey(x => x.ReporterId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.AuditLogs)
            .WithOne(x => x.Task)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Attachments)
            .WithOne(x => x.Task)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
