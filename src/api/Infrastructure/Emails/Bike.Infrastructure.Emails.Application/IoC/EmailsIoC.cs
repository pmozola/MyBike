using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.Emails.Application.IoC
{
    public static class EmailsIoC
    {
        public static IServiceCollection AddEmailsApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
