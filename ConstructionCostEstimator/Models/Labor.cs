using System.ComponentModel.DataAnnotations;

namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Catalog entity for labor entries used in construction cost estimates.
    /// Each labor record can be assigned to multiple projects through the join table.
    /// </summary>
    public class Labor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 100000)]
        public decimal Hours { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal HourlyRate { get; set; }

        public decimal TotalCost => Hours * HourlyRate;

        public string? Notes { get; set; }
    }
}