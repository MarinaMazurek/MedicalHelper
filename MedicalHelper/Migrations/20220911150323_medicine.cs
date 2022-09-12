using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class medicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Users_UserId",
                table: "Vaccination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccination",
                table: "Vaccination");

            migrationBuilder.RenameTable(
                name: "Vaccination",
                newName: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Medicines",
                newName: "FullCostOfMedicine");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccination_UserId",
                table: "Vaccinations",
                newName: "IX_Vaccinations_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CostOfMedicine",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccinations",
                table: "Vaccinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Users_UserId",
                table: "Vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccinations",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "CostOfMedicine",
                table: "Medicines");

            migrationBuilder.RenameTable(
                name: "Vaccinations",
                newName: "Vaccination");

            migrationBuilder.RenameColumn(
                name: "FullCostOfMedicine",
                table: "Medicines",
                newName: "Cost");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_UserId",
                table: "Vaccination",
                newName: "IX_Vaccination_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccination",
                table: "Vaccination",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Users_UserId",
                table: "Vaccination",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
