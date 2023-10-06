using GameStore.Application.Common.Interfaces;
using GameStore.Infrastructure.Persistence;
using GameStore.Infrastructure.Persistence.Interceptors;
using GameStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
            options.UseLazyLoadingProxies();
        });

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
