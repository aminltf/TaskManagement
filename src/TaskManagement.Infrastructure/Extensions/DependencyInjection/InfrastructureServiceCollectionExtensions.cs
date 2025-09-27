using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Common.Interfaces.Services;
using TaskManagement.Infrastructure.Auth.Services;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Extensions.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        // Register Services
        services.AddScoped<IJwtService, JwtService>();

        // Register JWT Settings
        services.AddJwtAuthentication(configuration);

        return services;
    }
}
