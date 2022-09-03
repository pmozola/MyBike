namespace Bike.Wishlist.Domain.Wish
{
    public interface IUserCategoryRepository
    {
        Task AddAsync(UserCategory userCategory, CancellationToken cancellationToken);
        Task<UserCategory?> GetAsync(int userId, int userCategoryId, CancellationToken cancellationToken);
    }
}
