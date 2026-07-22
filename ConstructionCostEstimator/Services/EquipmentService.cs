using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services;

public class EquipmentService
{
    private readonly ApplicationDbContext _context;

    public EquipmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Equipment>> GetEquipmentAsync(int projectId)
    {
        return await _context.Equipment
            .Where(e => e.ProjectId == projectId)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public async Task AddEquipmentAsync(Equipment equipment)
    {
        _context.Equipment.Add(equipment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEquipmentAsync(Equipment equipment)
    {
        _context.Equipment.Update(equipment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEquipmentAsync(int id)
    {
        var equipment = await _context.Equipment.FindAsync(id);

        if (equipment != null)
        {
            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetEquipmentTotalAsync(int projectId)
    {
        return await _context.Equipment
            .Where(e => e.ProjectId == projectId)
            .SumAsync(e => e.Days * e.DailyRate);
    }
}