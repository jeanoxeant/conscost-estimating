using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionCostEstimator.Migrations
{
    /// <inheritdoc />
    public partial class AlignDbSetsWithEstimatorModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEquipments_Equipment_EquipmentId",
                table: "ProjectEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLabors_Labor_LaborId",
                table: "ProjectLabors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialId",
                table: "ProjectMaterials");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "ProfitCost",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "TaxCost",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Labor",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "RatePerHour",
                table: "Labor",
                newName: "HourlyRate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Estimates",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Equipment",
                newName: "RentalUnit");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Equipment",
                newName: "RentalRate");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectMaterials",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectMaterials",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RatePerHour",
                table: "ProjectLabors",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "ProjectLabors",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectEquipments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectEquipments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Labor",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Labor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaterialCost",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "LaborCost",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EquipmentCost",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitAmount",
                table: "Estimates",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEquipments_Equipment_EquipmentId",
                table: "ProjectEquipments",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLabors_Labor_LaborId",
                table: "ProjectLabors",
                column: "LaborId",
                principalTable: "Labor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialId",
                table: "ProjectMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEquipments_Equipment_EquipmentId",
                table: "ProjectEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLabors_Labor_LaborId",
                table: "ProjectLabors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialId",
                table: "ProjectMaterials");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "ProfitAmount",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "Labor",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "HourlyRate",
                table: "Labor",
                newName: "RatePerHour");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "Estimates",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "RentalUnit",
                table: "Equipment",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "RentalRate",
                table: "Equipment",
                newName: "Unit");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectMaterials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectMaterials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "RatePerHour",
                table: "ProjectLabors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "ProjectLabors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectEquipments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProjectEquipments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Materials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Labor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Labor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaterialCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "LaborCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "EquipmentCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxCost",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Estimates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEquipments_Equipment_EquipmentId",
                table: "ProjectEquipments",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLabors_Labor_LaborId",
                table: "ProjectLabors",
                column: "LaborId",
                principalTable: "Labor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialId",
                table: "ProjectMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
