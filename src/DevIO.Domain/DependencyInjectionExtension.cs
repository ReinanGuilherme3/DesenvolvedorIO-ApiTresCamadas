using DevIO.Domain.Interfaces;
using DevIO.Domain.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Domain;

public static class DependencyInjectionExtension
{
    public static void AddDomain(this IServiceCollection services)
    {
        AddDomainServices(services);
        AddNotificador(services);
    }
    public static void AddDomainServices(IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(DependencyInjectionExtension))
            .AddClasses(classes => classes.InNamespaces("DevIO.Domain.Services"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    public static void AddNotificador(IServiceCollection services)
    {
        services.AddScoped<INotificador, Notificador>();
    }
}
