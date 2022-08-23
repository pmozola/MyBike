using Bike.Equipment.Database.DataSeed.TestData;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Equipment.Database.DataSeed
{
    public class EquipmentTestDataSeeder
    {
        private readonly BikeEquipmentDbContext dBContext;

        public EquipmentTestDataSeeder (BikeEquipmentDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Seed()
        {
            dBContext.Bike.AddRangeAsync(UserBikeTestData.Get());

            dBContext.SaveChanges();
        }
    }

    public static class EquipmentDataSeeder
    {
        public static IServiceProvider SeedEquipmentData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<EquipmentTestDataSeeder>().Seed();
            }

            return services;
        }
    }
}
