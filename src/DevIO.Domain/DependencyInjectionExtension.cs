using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Domain;

public static class DependencyInjectionExtension
{
    public static void AddDomain(this IServiceCollection services)
    {
        AddDomainServices(services);
    }
    public static void AddDomainServices(IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(DependencyInjectionExtension))
            .AddClasses(classes => classes.InNamespaces("DevIO.Domain.Services"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}
