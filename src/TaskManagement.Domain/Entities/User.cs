using TaskManagement.Shared.Abstractions;
using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class User : AuditableEntity<Guid>, ISoftDelete
{
    public Guid TenantId { get; set; } // FK → Tenant
    public Tenant Tenant { get; set; } = default!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; } // Soft Delete
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<Task> AssignedTasks { get; set; } = [];
    public ICollection<Task> ReportedTasks { get; set; } = [];

    public User() { }

    public User(Guid tenantId, string username, string email, string passwordHash, bool isActive, bool isDeleted)
    {
        TenantId = tenantId;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
        IsDeleted = isDeleted;
    }
}
