using Bike.Infrastructure.Garmin.Application.Database.Model;

namespace Bike.Equipment.Database.DataSeed.TestData
{
    public class UserGarminBikesTestData
    {
        public static IEnumerable<UserGarminBike> Get()
        {
            return new List<UserGarminBike>()
            {
              new UserGarminBike{BikeId = 1, BikeOwnerId = 16, UserName = "cnl12476@cdfaq.com", Password="TestGarmin2022", BikeFullName="Canyon Endurance CF 7 eTap"}
            };
        }
    }
}
