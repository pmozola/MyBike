using Bike.Wishlist.Database.Configuration;
using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Database
{
    public class WishlistDbContext : DbContext
    {
#pragma warning disable CS8618
        public WishlistDbContext(DbContextOptions<WishlistDbContext> options)
#pragma warning restore CS8618
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
