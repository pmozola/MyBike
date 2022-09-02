using Bike.Shared.Domain;

namespace Bike.Equipment.Domain.Parts
{
    public class BikePart : Enumeration
    {
        public static BikePart Frame = new(1, nameof(Frame));
        public static BikePart Saddle = new(2, nameof(Saddle));
        public static BikePart Seatpost = new(3, nameof(Seatpost));
        public static BikePart Rim = new(3, nameof(Rim));
        public static BikePart Tyre = new(4, nameof(Tyre));
        public static BikePart Handlebar = new(5, nameof(Handlebar));
        public static BikePart BottomBracket = new(6, nameof(BottomBracket));
        public static BikePart AirChamber = new(7, nameof(AirChamber));
        public static BikePart Chain = new(8, nameof(Chain));
        public static BikePart DiscBreake = new(9, nameof(DiscBreake));
        public static BikePart Crank = new(10, nameof(Crank));
        public static BikePart Pedal = new(11, nameof(Pedal));
        public static BikePart Fork = new(12, nameof(Fork));
        public static BikePart FrontDerailleur = new (13, nameof(FrontDerailleur));
        public static BikePart RearDerailleur = new(14, nameof(RearDerailleur));
        
        public BikePart(int id, string name) : base(id, name)
        {
        }
    }
}
