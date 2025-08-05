using TaskManagement.Shared.Abstractions;
using TaskManagement.Shared.Base;
using TaskManagement.Shared.Enums;
using TaskStatus = TaskManagement.Shared.Enums.TaskStatus;

namespace TaskManagement.Domain.Entities;

public class Task : AuditableEntity<Guid>, ISoftDelete
{
    public Guid TenantId { get; set; } // FK → Tenant
    public Tenant Tenant { get; set; } = default!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } // ToDo, Doing, Done, Blocked
    public TaskPriority Priority { get; set; } // Low, Medium, High, Critical
    public DateTime? DueDate { get; set; }
    public Guid AssignedToId { get; set; } // FK → User
    public User AssignedTo { get; set; } = default!;
    public Guid ReporterId { get; set; } // FK → User
    public User Reporter { get; set; } = default!;
    public bool IsDeleted { get; set; } // Soft Delete
    public ICollection<TaskAuditLog> AuditLogs { get; set; } = [];
    public ICollection<FileAttachment> Attachments { get; set; } = [];

    public Task() { }

    public Task(string title, string description, TaskStatus status, TaskPriority priority, DateTime? dueDate, Guid assignedToId, Guid reporterId, bool isDeleted)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        AssignedToId = assignedToId;
        ReporterId = reporterId;
        IsDeleted = isDeleted;
    }
}
