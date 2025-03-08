using System.ComponentModel.DataAnnotations;

namespace Orders.Model
{
    /// <summary>
    /// Order data model
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID
        /// </summary>
        [Key] public Guid Id { get; init; }
        /// <summary>
        /// City of Departure
        /// </summary>
        public required string DepartureCity { get; init; }
        /// <summary>
        /// Exact location of departure
        /// </summary>
        public required string DepartureLocation { get; init; }
        /// <summary>
        /// City of Arrival
        /// </summary>
        public required string ArrivalCity { get; init; }
        /// <summary>
        /// Exact location of arrival
        /// </summary>
        public required string ArrivalLocation { get; init; }
        /// <summary>
        /// Weight of the order
        /// </summary>
        public required float Weight { get; init; }
        /// <summary>
        /// Pickup Date
        /// </summary>
        public required DateOnly PickupDate { get; init; }
    }
}