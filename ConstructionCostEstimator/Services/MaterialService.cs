using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services;

public class MaterialService
{
    private readonly ApplicationDbContext _context;

    public MaterialService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectMaterial>> GetMaterialsAsync(int projectId)
    {
        return await _context.ProjectMaterials
            .Include(pm => pm.Material)
            .Where(pm => pm.ProjectId == projectId)
            .OrderBy(pm => pm.Material!.Name)
            .ToListAsync();
    }

    public async Task AddMaterialAsync(ProjectMaterial material)
    {
        _context.ProjectMaterials.Add(material);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMaterialAsync(ProjectMaterial material)
    {
        _context.ProjectMaterials.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMaterialAsync(int id)
    {
        var material = await _context.ProjectMaterials.FindAsync(id);

        if (material != null)
        {
            _context.ProjectMaterials.Remove(material);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetMaterialTotalAsync(int projectId)
    {
        return await _context.ProjectMaterials
            .Where(p => p.ProjectId == projectId)
            .SumAsync(p => p.Quantity * p.UnitPrice);
    }
}