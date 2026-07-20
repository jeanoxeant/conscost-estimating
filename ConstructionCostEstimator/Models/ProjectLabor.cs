using System.ComponentModel.DataAnnotations;

namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Join entity that captures labor entries assigned to a project.
    /// This supports the construction estimator workflow where labor is tracked per project.
    /// </summary>
    public class ProjectLabor
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        [Required]
        public int LaborId { get; set; }

        public Labor? Labor { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Hours { get; set; }

        [Range(0, double.MaxValue)]
        public decimal RatePerHour { get; set; }
    }
}
