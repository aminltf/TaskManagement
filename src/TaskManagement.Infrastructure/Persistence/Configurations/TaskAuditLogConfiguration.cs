using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class TaskAuditLogConfiguration : IEntityTypeConfiguration<TaskAuditLog>
{
    public void Configure(EntityTypeBuilder<TaskAuditLog> builder)
    {
        builder.ToTable("TaskAuditLogs");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Task)
            .WithMany(x => x.AuditLogs)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.Property(x => x.Action)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.ChangedBy)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.ChangeDate)
            .IsRequired();

        builder.Property(x => x.PreviousValue)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(x => x.NewValue)
            .HasColumnType("nvarchar(max)")
            .IsRequired();
    }
}
