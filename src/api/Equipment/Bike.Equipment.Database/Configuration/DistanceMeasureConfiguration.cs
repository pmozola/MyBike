using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Equipment.Database.Configuration
{
    public class DistanceMeasureConfiguration : IEntityTypeConfiguration<DistanceMeasure>
    {
        public void Configure(EntityTypeBuilder<DistanceMeasure> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.IsAddedManualy).IsRequired().HasDefaultValue(true);
            //TODO ignoreForNow
            builder.Ignore(x => x.Unit);
        }
    }
}
