using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCostEstimator.Models;

public class Labor
{
    public int Id { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Labor description is required.")]
    [StringLength(100)]
    public string Description { get; set; } = string.Empty;

    [Range(1,100, ErrorMessage = "Workers must be at least 1.")]
    public int Workers { get; set; }

    [Range(typeof(decimal), "0.5", "1000")]
    public decimal Hours { get; set; }

    [Range(typeof(decimal), "0.01", "100000")]
    public decimal HourlyRate { get; set; }

    [NotMapped]
    public decimal TotalCost =>
        Workers * Hours * HourlyRate;

    public Project? Project { get; set; }
}