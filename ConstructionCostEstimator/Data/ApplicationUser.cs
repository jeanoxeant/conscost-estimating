using ConstructionCostEstimator.Models;
using Microsoft.AspNetCore.Identity;

namespace ConstructionCostEstimator.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<Project> Projects { get; set; } = new();
}

