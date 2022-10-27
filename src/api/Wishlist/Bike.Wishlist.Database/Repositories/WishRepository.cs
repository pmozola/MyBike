using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Database.Repositories
{
    public class WishRepository : IWishRepository
    {
        private readonly WishlistDbContext _dbContext;

        public WishRepository(WishlistDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(WishAggregate wish, CancellationToken cancellationToken)
        {
            _dbContext.Add(wish);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<WishAggregate?> GetAsync(int id, int userId,  CancellationToken cancellationToken) => _dbContext.Wish
                .Where(x => x.Id == id && x.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);

        public Task DeleteAsync(WishAggregate entity, CancellationToken cancellationToken)
        {
            _dbContext.Wish.Remove(entity);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
