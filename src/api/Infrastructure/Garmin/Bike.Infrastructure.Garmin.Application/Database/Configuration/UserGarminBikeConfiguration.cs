using Bike.Infrastructure.Garmin.Application.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class UserGarminBikeConfiguration : IEntityTypeConfiguration<UserGarminBike>
    {
        public void Configure(EntityTypeBuilder<UserGarminBike> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.BikeFullName).IsRequired();
        }
    }
}
