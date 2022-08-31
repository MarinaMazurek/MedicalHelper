using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class firstffa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_DoctorId",
                table: "Medicines",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Doctor_DoctorId",
                table: "Medicines",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Doctor_DoctorId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_DoctorId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Medicines");
        }
    }
}
