using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services;

public class ProjectService
{
    private readonly ApplicationDbContext _context;

    public ProjectService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.ProjectMaterials)
            .Include(p => p.ProjectLabors)
            .Include(p => p.ProjectEquipments)
            .OrderByDescending(p => p.StartDate)
            .ToListAsync();
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.ProjectMaterials)
            .Include(p => p.ProjectLabors)
            .Include(p => p.ProjectEquipments)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddProjectAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProjectAsync(Project project)
    {
        var existingProject = await _context.Projects.FindAsync(project.Id);

        if (existingProject is null)
        {
            return;
        }

        existingProject.Name = project.Name;
        existingProject.Description = project.Description;
        existingProject.EstimatedCost = project.EstimatedCost;
        existingProject.StartDate = project.StartDate;
        existingProject.EndDate = project.EndDate;
        existingProject.Status = project.Status;
        existingProject.ApplicationUserId = project.ApplicationUserId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}