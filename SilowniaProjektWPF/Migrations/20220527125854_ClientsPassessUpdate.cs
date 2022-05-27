using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SilowniaProjektWPF.Migrations
{
    public partial class ClientsPassessUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Passes");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Passes");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Passes",
                newName: "PassType");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Passes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Passes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Passes");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Passes");

            migrationBuilder.RenameColumn(
                name: "PassType",
                table: "Passes",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Passes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Passes",
                type: "TEXT",
                nullable: true);
        }
    }
}
