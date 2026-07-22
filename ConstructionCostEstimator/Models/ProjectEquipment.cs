using System.ComponentModel.DataAnnotations;
//using ConstructionCostEstimator.Services;

namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Join entity that captures equipment items assigned to a project.
    /// This lets the estimator track rented or owned equipment usage by project.
    /// </summary>
    public class ProjectEquipment
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        public Equipment? Equipment { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
