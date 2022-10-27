using Bike.Infrastructure.Garmin.Application.Database.Configuration;
using Bike.Infrastructure.Garmin.Application.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Bike.Infrastructure.Garmin.Application.Database
{
    public class GarminDbContext : DbContext
    {
#pragma warning disable CS8618
        public GarminDbContext(DbContextOptions<GarminDbContext> options)
#pragma warning restore CS8618
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
