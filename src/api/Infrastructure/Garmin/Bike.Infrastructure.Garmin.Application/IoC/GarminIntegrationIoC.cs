using Bike.Equipment.Database;
using Bike.Equipment.Database.Configuration;
using Bike.Equipment.Database.DataSeed;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Equipment.Application.IoC
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
