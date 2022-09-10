using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class visit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Visits",
                newName: "SpecializationOfDoctor");

            migrationBuilder.AddColumn<string>(
                name: "FullNameOfDoctor",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameOfDoctor",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "SpecializationOfDoctor",
                table: "Visits",
                newName: "Name");
        }
    }
}
