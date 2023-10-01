using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GameStore.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using GameStore.Infrastructure.Persistence;

namespace GameStore.MVC;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUser, CurrentUser>();
        services.AddControllersWithViews();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        var tokenValidationParameters = new TokenValidationParameters()
        {
            // Token validation parameters
        };
        services.AddSingleton(tokenValidationParameters);

        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = tokenValidationParameters;
        });

        return services;
    }
}
