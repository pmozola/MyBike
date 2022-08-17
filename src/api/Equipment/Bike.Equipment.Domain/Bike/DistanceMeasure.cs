using Bike.Equipment.Domain.Shared;
using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Bike
{
    public class DistanceMeasure : Entity
    {
        public double Value { get; set; }
        public LengthUnit Unit { get; set; } = LengthUnit.Kilometer;
        public DateOnly Date { get; set; }
        public bool IsAddedManualy { get; set; } = true;
    }
}
