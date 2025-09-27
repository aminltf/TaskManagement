namespace TaskManagement.Application.Features.Auth.Dtos;

public class RegisterRequest
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid TenantId { get; set; }
}
