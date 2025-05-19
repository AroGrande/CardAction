using CardAction.Core.Actions;
using CardAction.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CardAction.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCardActionCore(this IServiceCollection services)
    {
        services.AddScoped<ActionService>();

        // Register all IAction implementations
        services.Scan(scan => scan
            .FromAssemblyOf<IAction>()
            .AddClasses(classes => classes.AssignableTo<IAction>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}
