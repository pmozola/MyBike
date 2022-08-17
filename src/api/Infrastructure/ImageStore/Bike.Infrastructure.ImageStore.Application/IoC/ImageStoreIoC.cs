using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.ImageStore.Application.IoC
{
    public static class ImageStoreIoC
    {
        public static IServiceCollection AddImageStoreApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}