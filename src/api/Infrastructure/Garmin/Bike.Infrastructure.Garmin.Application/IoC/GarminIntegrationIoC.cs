using Bike.Infrastructure.Garmin.Application.Database;
using Bike.Infrastructure.Garmin.Application.Database.Configuration;
using Bike.Infrastructure.Garmin.Application.Database.DataSeed;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.Garmin.Application.IoC
{
    public static class GarminIntegrationIoC
    {
        public static IServiceCollection AddGarminIntegrationApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(UserGarminBikeConfiguration).Assembly);

            services.AddDbContext<GarminDbContext>(
                options => options.UseInMemoryDatabase("Bike"));

            services.AddTransient<GarminTestDataSeeder>();

            return services;
        }
    }
}
