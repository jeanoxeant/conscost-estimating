namespace ConstructionCostEstimator.Models
{
    public class Materials
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        // Navigation property
        public List<ProjectMaterial> ProjectMaterials { get; set; } = new();
    }
}