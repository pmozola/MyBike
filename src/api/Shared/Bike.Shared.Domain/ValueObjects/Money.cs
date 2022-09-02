namespace Bike.Shared.Domain.ValueObjects
{
    public class Money
    {
        public Double Value { get; set; }
        public Currency Currency { get; set; }
    }

    public class Currency : Enumeration
    {
        public static Currency PLN = new(1, nameof(PLN));
        public static Currency Euro = new(2, nameof(Euro));
        public static Currency USD = new(3, nameof(USD));

        public Currency(int id, string name) : base(id, name)
        {
        }
    }
}
