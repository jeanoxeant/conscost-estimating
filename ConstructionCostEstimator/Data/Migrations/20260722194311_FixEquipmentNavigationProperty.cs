using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionCostEstimator.Migrations
{
    /// <inheritdoc />
    public partial class FixEquipmentNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "RentalRate",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "RentalUnit",
                table: "Equipment",
                newName: "DailyRate");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Labor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Workers",
                table: "Labor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Labor_ProjectId",
                table: "Labor",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ProjectId",
                table: "Equipment",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Projects_ProjectId",
                table: "Equipment",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_Projects_ProjectId",
                table: "Labor",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Projects_ProjectId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_Projects_ProjectId",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_ProjectId",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_ProjectId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "Workers",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "DailyRate",
                table: "Equipment",
                newName: "RentalUnit");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Labor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Equipment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalRate",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
