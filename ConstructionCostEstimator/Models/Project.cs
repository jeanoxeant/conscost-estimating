namespace ConstructionCostEstimator.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal EstimatedCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
        // Materials linked to this project
        public List<ProjectMaterial> ProjectMaterials { get; set; } = new();
    }

    public enum ProjectStatus
    {
        Planned,
        Active,
        Completed,
        OnHold,
        Cancelled
    }
}
