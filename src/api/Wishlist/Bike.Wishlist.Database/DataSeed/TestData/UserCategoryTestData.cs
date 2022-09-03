using Bike.Wishlist.Domain.Wish;

namespace Bike.Wishlist.Database.DataSeed.TestData
{
    public class UserCategoryTestData
    {
        public static IEnumerable<UserCategory> Get()
        {
            return new List<UserCategory>()
            {
                UserCategory.Create(16, "Buty", Category.Clothes.Id)
            };
        }
    }
}
