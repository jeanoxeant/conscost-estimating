namespace ConstructionCostEstimator.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        // Equipment name (e.g., Excavator, Concrete Mixer)
        public string Name { get; set; } = string.Empty;

        // Optional description
        public string? Description { get; set; }

        // Rental rate per hour/day (depending on your business rules)
        public decimal RentalRate { get; set; }

        // Unit used for the rental (Hour, Day, Week, etc.)
        public string RentalUnit { get; set; } = "Day";
    }
}