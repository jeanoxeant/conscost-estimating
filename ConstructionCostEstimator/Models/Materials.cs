namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Catalog entity for construction materials used in project estimates.
    /// Materials can be reused across multiple projects through the join table.
    /// </summary>
    public class Materials
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        // Navigation property that exposes material usage in project estimates.
        public List<ProjectMaterial> ProjectMaterials { get; set; } = new();
    }
}