using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCostEstimator.Models;

public class Equipment
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(1,365)]
    public int Days { get; set; }

    [Range(0,100000)]
    public decimal DailyRate { get; set; }

    [NotMapped]
    public decimal TotalCost => Days * DailyRate;

    public int ProjectId { get; set; }

    public Project? Project { get; set; }
}