namespace ConstructionCostEstimator.Models
{
    public class ProjectMaterial
    {
        public int Id { get; set; }

        // Foreign key to Project
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        // Foreign key to Material
        public int MaterialId { get; set; }

        public Materials? Material { get; set; }

        // Quantity of the material used in the project
        public decimal Quantity { get; set; }

        // Price per unit at the time of the estimate
        public decimal UnitPrice { get; set; }

        // Total cost for this material in the project
        public decimal TotalCost => Quantity * UnitPrice;
    }
}