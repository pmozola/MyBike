using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Database.Repositories
{
    public class UserCategoryRepository : IUserCategoryRepository
    {
        private readonly WishlistDbContext _dbContext;

        public UserCategoryRepository(WishlistDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(UserCategory userCategory, CancellationToken cancellationToken)
        {
            _dbContext.Add(userCategory);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<UserCategory?> GetAsync(int userId, int userCategoryId, CancellationToken cancellationToken) =>
        _dbContext.UserCategories
            .Where(x => x.UserId == userId)
            .Where(x => x.Id == userCategoryId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
