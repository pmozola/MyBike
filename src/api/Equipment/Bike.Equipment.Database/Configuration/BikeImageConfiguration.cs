using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class BikeImageConfiguration : IEntityTypeConfiguration<BikeImage>
    {
        public void Configure(EntityTypeBuilder<BikeImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
        }
    }
}
