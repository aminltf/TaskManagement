using TaskManagement.Shared.Abstractions;
using TaskManagement.Shared.Base;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Domain.Entities;

public class Notification : AuditableEntity<Guid>, ISoftDelete
{
    public Guid TenantId { get; set; } // FK → Tenant
    public Tenant Tenant { get; set; } = default!;
    public Guid UserId { get; set; } // FK → User
    public User User { get; set; } = default!;
    public string Message { get; set; } = null!;
    public NotificationType Type { get; set; } // TaskAssigned, TaskUpdated, ...
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; } // Soft Delete

    public Notification() { }

    public Notification(Guid tenantId, Guid userId, string message, NotificationType type, bool isRead, bool isDeleted)
    {
        TenantId = tenantId;
        UserId = userId;
        Message = message;
        Type = type;
        IsRead = isRead;
        IsDeleted = isDeleted;
    }
}
