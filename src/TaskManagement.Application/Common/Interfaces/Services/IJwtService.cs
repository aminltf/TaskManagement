using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Common.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user, IList<string> roles, Guid tenantId);
}
