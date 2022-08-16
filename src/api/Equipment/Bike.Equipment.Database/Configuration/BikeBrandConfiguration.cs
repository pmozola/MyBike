using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class BikeBrandConfiguration : IEntityTypeConfiguration<BikeBrand>
    {
        public void Configure(EntityTypeBuilder<BikeBrand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
