using Bike.Equipment.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class DistanceMeasureConfiguration : IEntityTypeConfiguration<DistanceMeasure>
    {
        public void Configure(EntityTypeBuilder<DistanceMeasure> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Distance,
                distance =>
                {
                    distance.Property(x => x.Value).IsRequired().HasColumnName("Value");
                    //TODO ignoreForNow
                    distance.Ignore(x => x.Unit);
                });
            builder.Property(x => x.AddedManually).IsRequired().HasDefaultValue(true);
        }
    }
}
