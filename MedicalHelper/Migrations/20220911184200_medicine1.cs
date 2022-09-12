using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class medicine1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameOfMedicine",
                table: "Medicines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullCostOfMedicine",
                table: "Medicines",
                newName: "FullCost");

            migrationBuilder.RenameColumn(
                name: "CostOfMedicine",
                table: "Medicines",
                newName: "Cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medicines",
                newName: "NameOfMedicine");

            migrationBuilder.RenameColumn(
                name: "FullCost",
                table: "Medicines",
                newName: "FullCostOfMedicine");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Medicines",
                newName: "CostOfMedicine");
        }
    }
}
