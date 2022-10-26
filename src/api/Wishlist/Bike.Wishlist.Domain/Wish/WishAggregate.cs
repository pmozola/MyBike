using Bike.Shared.Domain;
using Bike.Shared.Domain.Validators;

namespace Bike.Wishlist.Domain.Wish
{
    public class WishAggregate : IAggregate
    {
        public static WishAggregate CreateWish(int userId, string name, string url, int categoryId, UserCategory? userCategory, string description = "")
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException($"Passed url : {url} should not be empty.");
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"Passed name : {url}  should not be empty.");
            if (!UrlValidator.IsValid(url)) throw new ArgumentException($"Passed url : {url} is not valid.");
            if (!Enum.IsDefined(typeof(Category), categoryId)) throw new ArgumentException($"CategoryId: {categoryId} is not valid ");
            
            return new WishAggregate
            {
                UserId = userId,
                Name = name,
                Description = description,
                Url = url,
                Category = (Category)categoryId,
                UserCategory = userCategory
            };
        }
        private WishAggregate()
        {
        }

        public string Name { get; init; }
        public string Description { get; init; }
        public string Url { get; init; }

        public Category Category { get; init; }
        public UserCategory? UserCategory { get; init; }
        public int UserId { get; private set; }
    }
}
