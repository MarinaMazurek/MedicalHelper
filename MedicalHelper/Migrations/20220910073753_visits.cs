using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.Migrations
{
    public partial class visits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Doctor_DoctorId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Doctor_DoctorId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medicines",
                newName: "NameOfMedicine");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Medicines",
                newName: "VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_DoctorId",
                table: "Medicines",
                newName: "IX_Medicines_VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "VisitId",
                table: "Medicines",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "NameOfMedicine",
                table: "Medicines",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_VisitId",
                table: "Medicines",
                newName: "IX_Medicines_DoctorId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Doctor_DoctorId",
                table: "Medicines",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Doctor_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
