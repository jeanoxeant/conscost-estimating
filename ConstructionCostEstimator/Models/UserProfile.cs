namespace ConstructionCostEstimator.Models
{
    public class UserProfile
    {
        public string UserName { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Role { get; set; }
    }
}
