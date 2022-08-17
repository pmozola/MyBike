using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Shared
{
    public class LengthUnit : Enumeration
    {
        public static LengthUnit Kilometer = new(1, nameof(Kilometer));
        public static LengthUnit Mile = new(2, nameof(Mile));

        public LengthUnit(int id, string name)
            : base(id, name)
        {
        }
    }
}
