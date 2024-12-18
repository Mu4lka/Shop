using System.Reflection;

namespace Solution.Host.Utils.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServicesInExecutingAssembly(this IServiceCollection services, Type serviceType, ServiceLifetime lifetime)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == serviceType));

        foreach (var implementationType in types)
        {
            var a = implementationType.GetInterfaces();
            var interfaces = implementationType.GetInterfaces()
                .Where(i => i.GetInterfaces().Any(t => t.GetGenericTypeDefinition() == serviceType));
            foreach (var interfaceType in interfaces)
            {
                services.Add(new ServiceDescriptor(interfaceType, implementationType, lifetime));
            }
        }
        return services;
    }
}
