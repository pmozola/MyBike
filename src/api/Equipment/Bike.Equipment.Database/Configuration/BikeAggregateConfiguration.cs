using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class BikeAggregateConfiguration : IEntityTypeConfiguration<BikeAggregate>
    {
        public void Configure(EntityTypeBuilder<BikeAggregate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Brand).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.HasMany(x => x.DistanceMeasures).WithOne();
            builder.HasOne(x => x.Image);

            builder.Navigation(x => x.Image).AutoInclude();
            builder.Navigation(x => x.DistanceMeasures).AutoInclude();
        }
    }
}
