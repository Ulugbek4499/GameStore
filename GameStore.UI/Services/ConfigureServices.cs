using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using GameStore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationUser, CurrentUser>();
        services.AddScoped<IFileService, FileService>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddDatabaseDeveloperPageExceptionFilter();

/*        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();*/

        services.AddRazorPages();

        services.AddControllersWithViews();

        return services;
    }
}
