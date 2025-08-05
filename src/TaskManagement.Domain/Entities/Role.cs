using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class Role : AuditableEntity<Guid>
{
    public Guid TenantId { get; set; } // FK → Tenant
    public Tenant Tenant { get; set; } = default!;
    public string Name { get; set; } = null!; // Admin, Manager, PM, Developer, ...
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<RolePermission> RolePermissions { get; set; } = [];

    public Role() { }

    public Role(Guid tenantId, string name)
    {
        TenantId = tenantId;
        Name = name;
    }
}
