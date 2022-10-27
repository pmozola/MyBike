namespace Bike.Wishlist.Domain.Wish
{
    public interface IWishRepository
    {
        Task AddAsync(WishAggregate bike, CancellationToken cancellationToken);
        Task<WishAggregate?> GetAsync(int id, int userId, CancellationToken cancellationToken);
        Task DeleteAsync(WishAggregate entity, CancellationToken cancellationToken);
    }
}
