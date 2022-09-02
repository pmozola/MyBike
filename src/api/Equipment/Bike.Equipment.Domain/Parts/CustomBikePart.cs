using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Parts
{
    public class CustomBikePart : Entity
    {
        public int UserId { get; init; }
        public int Name { get; init; }
    }
}
