using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class firstff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Visits_VisitId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_VisitId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctor_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctor_DoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_VisitId",
                table: "Doctor",
                column: "VisitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Visits_VisitId",
                table: "Doctor",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
