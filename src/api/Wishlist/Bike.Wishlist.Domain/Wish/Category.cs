using Bike.Shared.Domain;

namespace Bike.Wishlist.Domain.Wish
{
    public class Category : Enumeration
    {
        public static Category Bike = new(1, nameof(Bike));
        public static Category BikeParts = new(2, nameof(BikeParts));
        public static Category Clothes = new(3, nameof(Clothes));
        public static Category Others = new(4, nameof(Others));

        public Category(int id, string name) : base(id, name)
        {
        }
    }
}
