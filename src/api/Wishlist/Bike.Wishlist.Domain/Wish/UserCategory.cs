using Bike.Shared.Domain;

namespace Bike.Wishlist.Domain.Wish
{
    public class UserCategory : Entity
    {
        private UserCategory() { }
        public static UserCategory Create(int userId, string name, int categoryId)
        {
            var category = Enumeration.GetAll<Category>().FirstOrDefault(x => x.Id == categoryId);
            if (category == null) throw new ArgumentException($"CategoryId: {categoryId} is not valid ");

            return new UserCategory { Name = name, UserId = userId, Category = category };
        }
        public string Name { get; init; } = string.Empty;
        public int UserId { get; init; }
        public Category Category { get; init; }
    }
}
