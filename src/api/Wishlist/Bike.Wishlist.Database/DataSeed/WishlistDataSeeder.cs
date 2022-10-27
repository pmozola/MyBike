using Bike.Wishlist.Database.DataSeed.TestData;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Wishlist.Database.DataSeed;

public class WishlistTestDataSeeder
{
    private readonly WishlistDbContext dBContext;

    public WishlistTestDataSeeder(WishlistDbContext dBContext)
    {
        this.dBContext = dBContext;
    }

    public void Seed()
    {
        var userCategories = UserCategoryTestData.Get().ToList();
        dBContext.UserCategories.AddRange(userCategories);
        dBContext.Wish.AddRange(WishTestData.Get(userCategories));

        dBContext.SaveChanges();
    }
}

public static class WishlistDataSeeder
{
    public static IServiceProvider SeedWishlistData(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<WishlistTestDataSeeder>().Seed();
        }

        return services;
    }
}
