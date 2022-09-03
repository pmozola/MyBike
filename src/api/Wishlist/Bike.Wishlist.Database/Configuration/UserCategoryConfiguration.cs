using Bike.Wishlist.Domain.Wish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bike.Wishlist.Database.Configuration
{
    internal class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
