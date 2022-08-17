using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Bike
{
    public class BikeAggregate : IAggregate
    {
        public static BikeAggregate CreateNewBike(string brand, string model, DateOnly purchaseDate, int ownerId)
        => new()
        {
            Brand = brand,
            Model = model,
            PurchaseDate = purchaseDate,
            OwnerId = ownerId
        };

        private BikeAggregate() { }

        public int OwnerId { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; } = string.Empty;
        public DateOnly PurchaseDate { get; init; }
        public BikeImage? Image { get; private set; }
        public string? FriendlyName { get; private set; }
        public List<DistanceMeasure> DistanceMeasures { get; set; } = new List<DistanceMeasure>();

        public void AddImage(string url)
        {
            Image = new BikeImage(url);
        }
    }

}
