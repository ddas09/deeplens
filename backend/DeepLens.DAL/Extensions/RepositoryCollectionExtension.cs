using DeepLens.DAL.Interfaces;
using DeepLens.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DeepLens.DAL.Extensions;

public static class RepositoryCollection
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEventRepository, EventRepository>();
    }
}