using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalHelper.DataBase.Migrations
{
    public partial class remove_visit_field_in_medicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "FullCost",
                table: "Medicines");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitId",
                table: "Medicines",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitId",
                table: "Medicines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FullCost",
                table: "Medicines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Visits_VisitId",
                table: "Medicines",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
