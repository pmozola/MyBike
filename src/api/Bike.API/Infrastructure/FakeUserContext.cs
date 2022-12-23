using Bike.Shared.Domain;

namespace Bike.API.Infrastructure
{
    public class FakeUserContext : IUserContext
    {
        public int GetUserId() => 16;
    }
}
