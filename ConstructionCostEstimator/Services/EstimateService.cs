using ConstructionCostEstimator.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services;

public class EstimateService
{
    private readonly ApplicationDbContext _context;

    public EstimateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> GetMaterialTotal(int projectId)
    {
        return await _context.ProjectMaterials
            .Where(pm => pm.ProjectId == projectId)
            .SumAsync(pm => pm.Quantity * pm.UnitPrice);
    }


    public async Task<decimal> GetLaborTotal(int projectId)
    {
        return await _context.Labor
            .Where(x => x.ProjectId == projectId)
            .SumAsync(x => x.Workers * x.Hours * x.HourlyRate);
    }

    public async Task<decimal> GetEquipmentTotal(int projectId)
    {
        return await _context.Equipment
            .Where(x => x.ProjectId == projectId)
            .SumAsync(x => x.Days * x.DailyRate);
    }

    public decimal CalculateTax(
    decimal materialCost,
    decimal laborCost,
    decimal equipmentCost,
    decimal taxPercentage)
    {
        // Calculates the project subtotal before applying taxes.
        decimal subtotal =
            materialCost +
            laborCost +
            equipmentCost;


        // Converts percentage input into decimal format.
        // Example: 7 becomes 0.07.
        decimal taxRate = taxPercentage / 100;


        // Returns the calculated tax amount.
        return subtotal * taxRate;
    }
}