﻿using Bike.Equipment.Domain.Shared;
using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Common
{
    public class DistanceMeasure : Entity
    {
        public Distance Distance { get; set; } = new();
        public DateTime Date { get; set; }
        public bool AddedManually { get; set; } = true;
    }
    public class Distance
    {
        public double Value { get; set; }
        public LengthUnit Unit { get; set; } = LengthUnit.Kilometer;
    }
}
