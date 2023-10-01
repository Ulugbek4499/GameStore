using Microsoft.OpenApi.Models;
using Serilog.Events;
using Serilog;
using System.Text.Json.Serialization;
using GameStore.Application.Common.Interfaces;
using GameStore.WebApi.Services;

namespace GameStore.WebApi;


public static class ConfigureServices
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddTransient<IUpdateHandler, UpdateHandler>();
        services.AddScoped<IUser, CurrentUser>();
        services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

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
