using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectReport>> GetProjectReportsAsync(string applicationUserId)
        {
            var projects = await _context.Projects
                .Where(p => p.ApplicationUserId == applicationUserId)
                .Include(p => p.ProjectMaterials)
                .AsNoTracking()
                .ToListAsync();

            var projectIds = projects.Select(p => p.Id).ToList();

            // Labor and Equipment are stored directly with a ProjectId FK, not via join tables.
            var labors = await _context.Labor
                .Where(l => projectIds.Contains(l.ProjectId))
                .AsNoTracking()
                .ToListAsync();

            var equipment = await _context.Equipment
                .Where(e => projectIds.Contains(e.ProjectId))
                .AsNoTracking()
                .ToListAsync();

            var estimates = await _context.Estimates
                .Where(e => projectIds.Contains(e.ProjectId))
                .AsNoTracking()
                .ToListAsync();

            return projects.Select(p => BuildSummary(
                p,
                labors.Where(l => l.ProjectId == p.Id).ToList(),
                equipment.Where(e => e.ProjectId == p.Id).ToList(),
                estimates.FirstOrDefault(e => e.ProjectId == p.Id)
            )).ToList();
        }

        public async Task<ProjectReport?> GetProjectReportAsync(int projectId, string applicationUserId)
        {
            var project = await _context.Projects
                .Where(p => p.Id == projectId && p.ApplicationUserId == applicationUserId)
                .Include(p => p.ProjectMaterials)
                    .ThenInclude(pm => pm.Material)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (project == null) return null;

            var labors = await _context.Labor
                .Where(l => l.ProjectId == projectId)
                .AsNoTracking()
                .ToListAsync();

            var equipment = await _context.Equipment
                .Where(e => e.ProjectId == projectId)
                .AsNoTracking()
                .ToListAsync();

            var estimate = await _context.Estimates
                .Where(e => e.ProjectId == projectId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var report = BuildSummary(project, labors, equipment, estimate);

            report.MaterialBreakdown = project.ProjectMaterials
                .Select(m => new CostBreakdownItem
                {
                    Name = m.Material?.Name ?? "Material",
                    Quantity = m.Quantity,
                    UnitCost = m.UnitPrice,
                    Unit = m.Material?.Unit ?? string.Empty
                }).ToList();

            // Quantity = Workers × Hours so that Total = Quantity × UnitCost = Workers × Hours × HourlyRate
            report.LaborBreakdown = labors
                .Select(l => new CostBreakdownItem
                {
                    Name = l.Description,
                    Quantity = l.Workers * l.Hours,
                    UnitCost = l.HourlyRate,
                    Unit = "hr"
                }).ToList();

            report.EquipmentBreakdown = equipment
                .Select(e => new CostBreakdownItem
                {
                    Name = e.Name,
                    Quantity = e.Days,
                    UnitCost = e.DailyRate,
                    Unit = "day"
                }).ToList();

            return report;
        }

        private static ProjectReport BuildSummary(Project project, List<Labor> labors, List<Equipment> equipment, Estimate? estimate)
        {
            decimal materialTotal  = project.ProjectMaterials.Sum(m => m.Quantity * m.UnitPrice);
            decimal laborTotal     = labors.Sum(l => l.Workers * l.Hours * l.HourlyRate);
            decimal equipmentTotal = equipment.Sum(e => e.Days * e.DailyRate);
            decimal taxPct    = estimate?.TaxPercentage ?? 0m;
            decimal taxAmount = estimate?.TaxAmount ?? 0m;

            return new ProjectReport
            {
                ProjectId          = project.Id,
                ProjectName        = project.Name,
                Description        = project.Description,
                StartDate          = project.StartDate,
                EndDate            = project.EndDate,
                Status             = project.Status,
                TotalMaterialCost  = materialTotal,
                TotalLaborCost     = laborTotal,
                TotalEquipmentCost = equipmentTotal,
                TaxPercentage      = taxPct,
                TaxAmount          = taxAmount,
                MaterialItemCount  = project.ProjectMaterials.Count,
                LaborItemCount     = labors.Count,
                EquipmentItemCount = equipment.Count
            };
        }
    }
}