using Bike.Equipment.Domain.Bike;

namespace Bike.Equipment.Database.DataSeed.TestData
{
    public class UserBikeTestData
    {
        public static IEnumerable<BikeAggregate> Get()
        {
            return new List<BikeAggregate>()
            {
                BikeAggregate.CreateNewBike("Canyon", "Endurence CF", DateOnly.FromDateTime(new DateTime(2022,8,29)), 16)
            };
        }
    }
}
