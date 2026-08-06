using ConstructionCostEstimator.Models;

namespace ConstructionCostEstimator.Models
{
    /// <summary>
    /// Aggregated cost report for a single project, used by the dashboard's Report section.
    /// </summary>
    public class ProjectReport
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; }

        public decimal TotalMaterialCost { get; set; }
        public decimal TotalLaborCost { get; set; }
        public decimal TotalEquipmentCost { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal Subtotal => TotalMaterialCost + TotalLaborCost + TotalEquipmentCost;
        public decimal TotalCost => Subtotal + TaxAmount;

        public int MaterialItemCount { get; set; }
        public int LaborItemCount { get; set; }
        public int EquipmentItemCount { get; set; }

        public List<CostBreakdownItem> MaterialBreakdown { get; set; } = new();
        public List<CostBreakdownItem> LaborBreakdown { get; set; } = new();
        public List<CostBreakdownItem> EquipmentBreakdown { get; set; } = new();
    }

    public class CostBreakdownItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal Total => Quantity * UnitCost;
    }
}