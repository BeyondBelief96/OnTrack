using Microsoft.Extensions.DependencyInjection;

namespace OnTrack.Factory;

public static class ServiceExtensions
{
    public static void AddViewFactory<TView>(this IServiceCollection services)
        where TView : class
    {
        services.AddTransient<TView>();
        services.AddSingleton<Func<TView>>(x => () => x.GetService<TView>()!);
        services.AddSingleton<IAbstractFactory<TView>, AbstractFactory<TView>>();
    }
}
