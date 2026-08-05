using ConstructionCostEstimator.Data;
using ConstructionCostEstimator.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Services
{
    /// <summary>
    /// Builds aggregated cost reports for projects, used by the Reports dashboard page.
    /// </summary>
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a summary report (no line-item breakdown) for every project owned by the given user.
        /// </summary>
        public async Task<List<ProjectReport>> GetProjectReportsAsync(string applicationUserId)
        {
            var projects = await _context.Projects
                .Where(p => p.ApplicationUserId == applicationUserId)
                .Include(p => p.ProjectMaterials)
                .Include(p => p.ProjectLabors)
                .Include(p => p.ProjectEquipments)
                .AsNoTracking()
                .ToListAsync();

            return projects.Select(BuildSummary).ToList();
        }

        /// <summary>
        /// Returns a detailed report, including line-item breakdowns, for a single project.
        /// </summary>
        public async Task<ProjectReport?> GetProjectReportAsync(int projectId, string applicationUserId)
        {
            var project = await _context.Projects
                .Where(p => p.Id == projectId && p.ApplicationUserId == applicationUserId)
                .Include(p => p.ProjectMaterials)
                .Include(p => p.ProjectLabors)
                .Include(p => p.ProjectEquipments)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (project == null)
            {
                return null;
            }

            var report = BuildSummary(project);

            // NOTE: adjust property names below (Name/Quantity/UnitCost) to match your entities.
            report.MaterialBreakdown = project.ProjectMaterials
                .Select(m => new CostBreakdownItem
                {
                    Name = m.GetType().GetProperty("Name")?.GetValue(m)?.ToString() ?? "Material",
                    Quantity = ToDecimal(m.GetType().GetProperty("Quantity")?.GetValue(m)),
                    UnitCost = ToDecimal(m.GetType().GetProperty("UnitCost")?.GetValue(m))
                }).ToList();

            report.LaborBreakdown = project.ProjectLabors
                .Select(l => new CostBreakdownItem
                {
                    Name = l.GetType().GetProperty("Name")?.GetValue(l)?.ToString() ?? "Labor",
                    Quantity = ToDecimal(l.GetType().GetProperty("Quantity")?.GetValue(l)),
                    UnitCost = ToDecimal(l.GetType().GetProperty("UnitCost")?.GetValue(l))
                }).ToList();

            report.EquipmentBreakdown = project.ProjectEquipments
                .Select(e => new CostBreakdownItem
                {
                    Name = e.GetType().GetProperty("Name")?.GetValue(e)?.ToString() ?? "Equipment",
                    Quantity = ToDecimal(e.GetType().GetProperty("Quantity")?.GetValue(e)),
                    UnitCost = ToDecimal(e.GetType().GetProperty("UnitCost")?.GetValue(e))
                }).ToList();

            return report;
        }

        private static ProjectReport BuildSummary(Project project)
        {
            decimal materialTotal = 0, laborTotal = 0, equipmentTotal = 0;

            // Reflection fallback in case exact property names differ; replace with direct
            // access (e.g. m.Quantity * m.UnitCost) once your entity shapes are confirmed.
            foreach (var m in project.ProjectMaterials)
                materialTotal += SafeLineTotal(m);
            foreach (var l in project.ProjectLabors)
                laborTotal += SafeLineTotal(l);
            foreach (var e in project.ProjectEquipments)
                equipmentTotal += SafeLineTotal(e);

            return new ProjectReport
            {
                ProjectId = project.Id,
                ProjectName = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
                TotalMaterialCost = materialTotal,
                TotalLaborCost = laborTotal,
                TotalEquipmentCost = equipmentTotal,
                MaterialItemCount = project.ProjectMaterials.Count,
                LaborItemCount = project.ProjectLabors.Count,
                EquipmentItemCount = project.ProjectEquipments.Count
            };
        }

        private static decimal SafeLineTotal(object entity)
        {
            var qty = ToDecimal(entity.GetType().GetProperty("Quantity")?.GetValue(entity));
            var unitCost = ToDecimal(entity.GetType().GetProperty("UnitCost")?.GetValue(entity));
            return qty * unitCost;
        }

        private static decimal ToDecimal(object? value)
        {
            if (value == null) return 0m;
            return Convert.ToDecimal(value);
        }
    }
}