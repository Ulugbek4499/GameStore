using System.Text;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using GameStore.Infrastructure.Persistence;
using GameStore.MVC.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameStore.MVC;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationUser, CurrentUser>();
        services.AddControllersWithViews();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}
