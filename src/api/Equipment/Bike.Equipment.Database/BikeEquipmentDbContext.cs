using Bike.Equipment.Database.Configuration;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BikeAggregateConfiguration).Assembly);
        }

        public DbSet<BikeAggregate> Bike { get; set; }
        public DbSet<BikeImage> BikeImages { get; set; }
        public DbSet<DistanceMeasure> DistanceMeasures { get; set; }
    }
}
