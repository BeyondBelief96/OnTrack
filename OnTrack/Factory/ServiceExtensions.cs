using Microsoft.Extensions.DependencyInjection;

namespace OnTrack.Factory;

public static class ServiceExtensions
{
    public static void AddServiceFactory<TService>(this IServiceCollection services)
        where TService : class
    {
        services.AddTransient<TService>();
        services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>()!);
        services.AddSingleton<IAbstractFactory<TService>, AbstractFactory<TService>>();
    }
}
