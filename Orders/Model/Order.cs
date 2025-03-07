using System.ComponentModel.DataAnnotations;

namespace Orders.Model
{
    public class Order
    {
        [Key] public Guid Id { get; init; }
        public required string DepartureCity { get; init; }
        public required string DepartureLocation { get; init; }
        public required string ArrivalCity { get; init; }
        public required string ArrivalLocation { get; init; }
        public required float Weight { get; init; }
        public required DateOnly PickupDate { get; init; }
    }
}