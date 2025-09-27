namespace TaskManagement.Application.Features.Auth.Dtos;

public class LoginRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid TenantId { get; set; }
}
