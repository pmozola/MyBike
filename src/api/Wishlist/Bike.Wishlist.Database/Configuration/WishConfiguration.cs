using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Wishlist.Database.Configuration
{
    public class WishConfiguration : IEntityTypeConfiguration<WishAggregate>
    {
        public void Configure(EntityTypeBuilder<WishAggregate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
