using DeepLens.Services.Implementations;
using DeepLens.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DeepLens.Services.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
    }
}