using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class TaskAuditLog : BaseEntity<Guid>
{
    public Guid TaskId { get; set; } // FK → Task
    public Task Task { get; set; } = default!;
    public string Action { get; set; } = null!; // Created, Updated, Deleted, ...
    public Guid ChangedBy { get; set; } // FK → User
    public User User { get; set; } = default!;
    public DateTime ChangeDate { get; set; }
    public string PreviousValue { get; set; } = null!; // JSON
    public string NewValue { get; set; } = null!; // JSON

    public TaskAuditLog() { }

    public TaskAuditLog(Guid taskId, string action, Guid changedBy, DateTime changeDate, string previousValue, string nextValue)
    {
        TaskId = taskId;
        Action = action;
        ChangedBy = changedBy;
        ChangeDate = changeDate;
        PreviousValue = previousValue;
        NewValue = nextValue;
    }
}
