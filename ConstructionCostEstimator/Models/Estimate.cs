using System.ComponentModel.DataAnnotations;

namespace ConstructionCostEstimator.Models
{
    /// Represents the complete cost estimate for a construction project.
    /// This model stores the calculated totals for materials, labor,
    /// equipment, taxes, profit, and the final estimated project cost.

    public class Estimate
    {
        // Primary key for the estimate.
        public int Id { get; set; }

        // Foreign key that identifies the project this estimate belongs to.
        [Required]
        public int ProjectId { get; set; }

        // Navigation property to the associated construction project.
        public Project? Project { get; set; }

        // Total calculated cost of all materials used in the project.
        [Range(0, double.MaxValue)]
        public decimal MaterialCost { get; set; }

        // Total calculated labor cost based on hours and hourly rates.
        [Range(0, double.MaxValue)]
        public decimal LaborCost { get; set; }

        // Total rental cost for all equipment used in the project.
        [Range(0, double.MaxValue)]
        public decimal EquipmentCost { get; set; }

        // Total amount added for taxes.
        [Range(0, double.MaxValue)]
        public decimal TaxAmount { get; set; }

        // Total profit amount added to the estimate.
        [Range(0, double.MaxValue)]
        public decimal ProfitAmount { get; set; }

        // Final calculated cost of the project.
        // This value includes materials, labor, equipment,
        // taxes, and profit.
        [Range(0, double.MaxValue)]
        public decimal TotalCost { get; set; }

        // Date and time when the estimate was created.
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}