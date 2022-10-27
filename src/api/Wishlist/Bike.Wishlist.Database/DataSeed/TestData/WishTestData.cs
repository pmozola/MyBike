using Bike.Wishlist.Domain.Wish;

namespace Bike.Wishlist.Database.DataSeed.TestData
{
    public class WishTestData
    {
        public static IEnumerable<WishAggregate> Get(IEnumerable<UserCategory> userCategories)
        {
            return new List<WishAggregate>()
            {
                WishAggregate.CreateWish(16, "Some", "http://abc.pl", (int)Category.Clothes, userCategory: userCategories.FirstOrDefault())
            };
        }
    }
}
