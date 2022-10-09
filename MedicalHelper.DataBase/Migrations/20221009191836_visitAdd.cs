using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.DataBase.Migrations
{
    public partial class visitAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecializationOfDoctor",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "Specialization",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Visits");

            migrationBuilder.AddColumn<string>(
                name: "SpecializationOfDoctor",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
