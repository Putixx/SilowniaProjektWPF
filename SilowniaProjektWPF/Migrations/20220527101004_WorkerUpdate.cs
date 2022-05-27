using Microsoft.EntityFrameworkCore.Migrations;

namespace SilowniaProjektWPF.Migrations
{
    public partial class WorkerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HourlyCost",
                table: "Workers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorIndex",
                table: "Workers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Workers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyCost",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "InstructorIndex",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Workers");
        }
    }
}
