using Bike.Equipment.Database.Configuration;
using Bike.Infrastructure.Garmin.Application.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Bike.Equipment.Database
{
    public class GarminDbContext : DbContext
    {
        public GarminDbContext(DbContextOptions<GarminDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("garmin");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserGarminBikeConfiguration).Assembly);
        }

        public DbSet<UserGarminBike> UserGarminBikes { get; set; }
    }
}
