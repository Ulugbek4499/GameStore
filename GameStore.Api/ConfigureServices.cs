using System.Text.Json.Serialization;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using GameStore.Infrastructure.Persistence;
using GameStore.WebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace GameStore.WebApi;


public static class ConfigureServices
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationUser, CurrentUser>();
        services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
        services.AddSwaggerGen();


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example API", Version = "v1" });

        });
        return services;
    }
}
