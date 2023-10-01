using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.Common.Interfaces;
using GameStore.Infrastructure.Persistence.Interceptors;
using GameStore.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GameStore.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using GameStore.Domain.Entities.Identity;

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

        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
}
