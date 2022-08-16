using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;

namespace Bike.Equipment.Database
{
    public class BikeEquipmentDbContext : DbContext
    {
        public BikeEquipmentDbContext(DbContextOptions<BikeEquipmentDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Equipment");
        }

        public DbSet<BikeAggregate> Bike { get; set; }
        public DbSet<BikeBrand> BikeBrand { get; set; }
        public DbSet<BikeImage> BikeImages { get; set; }
    }
}
