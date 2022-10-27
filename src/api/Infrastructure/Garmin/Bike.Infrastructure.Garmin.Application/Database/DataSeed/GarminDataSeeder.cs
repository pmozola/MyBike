using Bike.Infrastructure.Garmin.Application.Database.DataSeed.TestData;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Infrastructure.Garmin.Application.Database.DataSeed
{
    public class GarminTestDataSeeder
    {
        private readonly GarminDbContext dBContext;

        public GarminTestDataSeeder(GarminDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Seed()
        {
            dBContext.UserGarminBikes.AddRangeAsync(UserGarminBikesTestData.Get());

            dBContext.SaveChanges();
        }
    }

    public static class GarminDataSeeder
    {
        public static IServiceProvider SeedGarminData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<GarminTestDataSeeder>().Seed();
            }

            return services;
        }
    }
}
