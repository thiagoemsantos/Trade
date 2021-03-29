using Microsoft.Extensions.DependencyInjection;
using Trade.Core;
using Trade.Notification.Interfaces;
using Trade.Notification.Notifications;

namespace Trade.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ITradeFactory, TradeFactory>();
            return services;
        }
    }
}
