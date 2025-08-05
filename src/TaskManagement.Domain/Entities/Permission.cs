using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class Permission : BaseEntity<Guid>
{
    public string Name { get; set; } = null!; // EditTask, CreateTask, ...
    public string Description { get; set; } = default!;
    public ICollection<RolePermission> RolePermissions { get; set; } = [];

    public Permission(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
