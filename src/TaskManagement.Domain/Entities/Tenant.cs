using TaskManagement.Shared.Base;

namespace TaskManagement.Domain.Entities;

public class Tenant : AuditableEntity<Guid>
{
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = [];
    public ICollection<Role> Roles { get; set; } = [];
    public ICollection<Task> Tasks { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];

    public Tenant() { }

    public Tenant(string name)
    {
        Name = name;
    }
}
