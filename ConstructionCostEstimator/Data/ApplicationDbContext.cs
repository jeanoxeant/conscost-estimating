using ConstructionCostEstimator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCostEstimator.Data;

/// <summary>
/// Entity Framework Core context for the construction cost estimator application.
/// This context exposes the project, estimate, material, labor, equipment, and join-table entities
/// used by the Blazor application and Identity authentication layer.
/// </summary>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // Core project planning and estimate data.
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Estimate> Estimates => Set<Estimate>();

    // Catalog-style estimator data.
    public DbSet<Materials> Materials => Set<Materials>();
    public DbSet<Labor> Labor => Set<Labor>();
    public DbSet<Equipment> Equipment => Set<Equipment>();

    // Join entities that tie the catalog items to a specific project.
    public DbSet<ProjectMaterial> ProjectMaterials => Set<ProjectMaterial>();
    public DbSet<ProjectLabor> ProjectLabors => Set<ProjectLabor>();
    public DbSet<ProjectEquipment> ProjectEquipments => Set<ProjectEquipment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure the ownership relationship between a user and their projects.
        builder.Entity<Project>()
            .HasOne(p => p.Owner)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the one-to-many relationship between a project and its estimate.
        builder.Entity<Estimate>()
            .HasOne(e => e.Project)
            .WithMany()
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the project-to-material join relationship.
        builder.Entity<ProjectMaterial>()
            .HasOne(pm => pm.Project)
            .WithMany(p => p.ProjectMaterials)
            .HasForeignKey(pm => pm.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProjectMaterial>()
            .HasOne(pm => pm.Material)
            .WithMany(m => m.ProjectMaterials)
            .HasForeignKey(pm => pm.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the project-to-labor join relationship.
        builder.Entity<ProjectLabor>()
            .HasOne(pl => pl.Project)
            .WithMany(p => p.ProjectLabors)
            .HasForeignKey(pl => pl.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProjectLabor>()
            .HasOne(pl => pl.Labor)
            .WithMany()
            .HasForeignKey(pl => pl.LaborId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the project-to-equipment join relationship.
        builder.Entity<ProjectEquipment>()
            .HasOne(pe => pe.Project)
            .WithMany(p => p.ProjectEquipments)
            .HasForeignKey(pe => pe.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProjectEquipment>()
            .HasOne(pe => pe.Equipment)
            .WithMany()
            .HasForeignKey(pe => pe.EquipmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
