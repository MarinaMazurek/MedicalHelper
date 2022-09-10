using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctor",
                newName: "Specialization");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Doctor",
                newName: "Name");
        }
    }
}
