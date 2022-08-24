namespace Bike.Equipment.Domain.Bike
{
    public interface IBikeRepository
    {
        Task AddAsync(BikeAggregate bike, CancellationToken cancellationToken);
        Task<BikeAggregate?> GetAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(BikeAggregate bike, CancellationToken cancellationToken);
    }
}
