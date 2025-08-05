namespace TaskManagement.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; } // FK → User
    public User User { get; set; } = default!;
    public Guid RoleId { get; set; } // FK → Role
    public Role Role { get; set; } = default!;

    public UserRole() { }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}
