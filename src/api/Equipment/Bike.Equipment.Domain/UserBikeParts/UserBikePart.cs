using Bike.Equipment.Domain.Common;
using Bike.Shared.Domain;
using Bike.Shared.Domain.ValueObjects;

namespace Bike.Equipment.Domain.UserBikeParts
{
    public class UserBikePart : IAggregate
    {
        public UserBikePart(int bikePartId, int customBikePartId)
        {
            BikePartId = bikePartId;
            CustomBikePartId = customBikePartId;
        }

        public int BikePartId { get; init; }
        public int CustomBikePartId { get; init; }
        public DateTime BoughtDate { get; init; }
        public Money? BoughtPrice { get; init; }
        public DateTime FirstUse { get; init; }
        public Expiration? PartExpiration { get; init; }
        public List<DistanceMeasure> DistanceMeasures { get; init; } = new List<DistanceMeasure>();
        public Distance TotalDistance() => new()
        {
            Value = DistanceMeasures.Sum(x => x.Distance.Value),
            Unit = Shared.LengthUnit.Kilometer
        };
       
        public class Expiration : Entity
        {
            public DateTime ExpirationDate { get; set; }

            public Distance? ExpirationTotalDistance { get; set; }
        }
    }
}
