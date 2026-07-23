using ConstructionCostEstimator.Data;
using System.ComponentModel.DataAnnotations;

namespace ConstructionCostEstimator.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Estimated cost must be zero or greater.")]
        public decimal EstimatedCost { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public ProjectStatus Status { get; set; } = ProjectStatus.Planned;

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser? Owner { get; set; }

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
