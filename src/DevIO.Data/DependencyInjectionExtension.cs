using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Data;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DevIODbContext>(dbContextOptions
            => dbContextOptions.UseSqlServer(connectionString));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(DependencyInjectionExtension))
            .AddClasses(classes => classes.InNamespaces("DevIO.Data.Repositories"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}