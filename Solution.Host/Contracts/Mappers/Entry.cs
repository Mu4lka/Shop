using Solution.Host.Utils.DI;

namespace Solution.Host.Contracts.Mappers;

public static class Entry
{
    public static IServiceCollection ConfigureMappers(this IServiceCollection services)
    {
        services.AddServicesInExecutingAssembly(typeof(IModelMapper<>), ServiceLifetime.Scoped);

        return services;
    }
}
