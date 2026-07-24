using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCostEstimator.Models;

public class Labor
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    [Required]
    public string Description { get; set; } = "";

    public int Workers { get; set; }

    public decimal Hours { get; set; }

    public decimal HourlyRate { get; set; }

    [NotMapped]
    public decimal TotalCost =>
        Workers * Hours * HourlyRate;

    public Project? Project { get; set; }
}