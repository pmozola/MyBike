using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.Strava.Application.IoC
{
    public static class StravaIoC
    {
        public static IServiceCollection AddStravaApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
