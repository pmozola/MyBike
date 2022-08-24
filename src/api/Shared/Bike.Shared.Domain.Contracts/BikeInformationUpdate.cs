using MediatR;

namespace Bike.Shared.Domain.Contracts
{
    public class NewBikeActivitiesIntegrationEvent : INotification
    {
        public NewBikeActivitiesIntegrationEvent(int bikeId, double updatedTotalDistance, int newTotalActivities, double oldTotalDistance, int oldTotalActivities)
        {
            TotalDistance = updatedTotalDistance;
            NewDistance = updatedTotalDistance - oldTotalDistance;
            LastUpdateTime = DateTime.Now;
            NewActivities = newTotalActivities - oldTotalActivities;
            BikeId = bikeId;
        }

        public int BikeId { get; set; }
        public int NewActivities { get; init; }
        public DateTime LastUpdateTime { get; init; }
        public double TotalDistance { get; init; }
        public double NewDistance { get; init; }
    }
}
