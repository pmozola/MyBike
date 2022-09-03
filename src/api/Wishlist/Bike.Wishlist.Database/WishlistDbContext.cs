using Bike.Wishlist.Database.Configuration;
using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Database
{
    public class WishlistDbContext : DbContext
    {
        public WishlistDbContext(DbContextOptions<WishlistDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Wishlist");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WishConfiguration).Assembly);
        }

        public DbSet<WishAggregate> Wish { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
    }
}
