namespace Bike.Equipment.Domain.Bike
{
    public interface IBikeRepository
    {
        Task AddAsync(BikeAggregate bike, CancellationToken cancellationToken);
    }
}
