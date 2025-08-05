namespace TaskManagement.Domain.Entities;

public class RolePermission
{
    public Guid RoleId { get; set; } // FK → Role
    public Role Role { get; set; } = default!;
    public Guid PermissionId { get; set; } // FK → Permission
    public Permission Permission { get; set; } = default!;

    public RolePermission() { }

    public RolePermission(Guid roleId, Guid permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
}
