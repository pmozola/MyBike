using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.PushNotification.Application.IoC
{
    public static class PushNotificationIoC
    {
        public static IServiceCollection AddPushNotificationApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
