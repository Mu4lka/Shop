using FluentMigrator.Runner;

namespace Solution.Host.Infrastructure.Store.Migrations;

public static class Entry
{
    public static void StartMigrator(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("DatabaseMsSql"))
                .ScanIn(typeof(CreateUsersTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
