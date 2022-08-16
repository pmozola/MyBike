using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Bike
{
    public class BikeAggregate : IAggregate
    {
        public static BikeAggregate CreateNewBike(BikeBrand brand, string model, DateOnly purchaseDate)
        => new()
        {
            Brand = brand,
            Model = model,
            PurchaseDate = purchaseDate,
        };

        public BikeBrand Brand { get; init; }

        public string Model { get; init; } = string.Empty;

        public DateOnly PurchaseDate { get; init; }
        public BikeImage? Image { get; private set; }

        public void AddImage(string url)
        {
            Image = new BikeImage(url);
        }
    }

}
