using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services;

public class LaborService
{
    private readonly ApplicationDbContext _context;

    public LaborService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Labor>> GetLaborAsync(int projectId)
    {
        return await _context.Labor
            .Where(l => l.ProjectId == projectId)
            .OrderBy(l => l.Description)
            .ToListAsync();
    }

    public async Task AddLaborAsync(Labor labor)
    {
        _context.Labor.Add(labor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLaborAsync(Labor labor)
    {
        _context.Labor.Update(labor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLaborAsync(int id)
    {
        var labor = await _context.Labor.FindAsync(id);

        if (labor != null)
        {
            _context.Labor.Remove(labor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetLaborTotalAsync(int projectId)
    {
        return await _context.Labor
            .Where(l => l.ProjectId == projectId)
            .SumAsync(l => l.Workers * l.Hours * l.HourlyRate);
    }
}