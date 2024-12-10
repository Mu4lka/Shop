using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Endpoints.Services;
using Solution.Host.Infrastructure.Services;
using Solution.Host.Infrastructure.Store.Repositories;

namespace Solution.Host.Infrastructure;

internal static class Entry
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>()
            .AddScoped<IJwtGenerator, JwtGenerator>()
            .AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();

        return services;
    }
}
