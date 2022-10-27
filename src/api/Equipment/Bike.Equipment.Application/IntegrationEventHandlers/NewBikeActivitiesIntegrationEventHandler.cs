using Bike.Equipment.Domain.Bike;
using Bike.Equipment.Domain.Common;
using Bike.Shared.Domain.Contracts;
using Bike.Shared.Domain.Exceptions;
using MediatR;

namespace Bike.Equipment.Application.IntegrationEventHandlers
{
    public class NewBikeActivitiesIntegrationEventHandler : INotificationHandler<NewBikeActivitiesIntegrationEvent>
    {
        private readonly IBikeRepository bikeRepository;

        public NewBikeActivitiesIntegrationEventHandler(IBikeRepository bikeRepository)
        {
            this.bikeRepository = bikeRepository;
        }

        public async Task Handle(NewBikeActivitiesIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var bike = await this.bikeRepository.GetAsync(notification.BikeId, cancellationToken);

            if (bike == null) throw new NotFoundDomainException();

            bike.DistanceMeasures.Add(new DistanceMeasure
            {
                Date = notification.LastUpdateTime,
                AddedManually = false,
                Distance = new Distance
                {
                    Unit = Domain.Shared.LengthUnit.Kilometer,
                    Value = notification.NewDistance / 1000
                }
            });

            await this.bikeRepository.UpdateAsync(bike, cancellationToken);
        }
    }
}
