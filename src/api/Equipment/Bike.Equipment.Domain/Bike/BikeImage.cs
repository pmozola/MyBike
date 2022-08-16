using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Bike
{
    public class BikeImage : Entity
    {
        public BikeImage(string url)
        {
            Url = url;
        }

        public string Url { get; init; }
    }
}
