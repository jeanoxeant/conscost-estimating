using ConstructionCostEstimator.Data;

namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Represents a single construction project managed by the estimator.
    /// Each project belongs to an authenticated user and can contain multiple estimate-related records.
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal EstimatedCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Planned;

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser? Owner { get; set; }

        // Materials linked to this project.
        public List<ProjectMaterial> ProjectMaterials { get; set; } = new();

        // Labor entries linked to this project.
        public List<ProjectLabor> ProjectLabors { get; set; } = new();

        // Equipment items linked to this project.
        public List<ProjectEquipment> ProjectEquipments { get; set; } = new();
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
