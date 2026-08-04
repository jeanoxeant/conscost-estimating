using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionCostEstimator.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedCost",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
