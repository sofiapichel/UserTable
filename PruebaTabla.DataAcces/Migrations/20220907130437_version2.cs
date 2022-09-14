using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTabla.DataAcces.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InscripcionUsuario",
                table: "Usuarios",
                newName: "FechaInscripcion");

            migrationBuilder.RenameColumn(
                name: "EdadUsuario",
                table: "Usuarios",
                newName: "Edad");

            migrationBuilder.AddColumn<DateTime>(
                name: "Edad2",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Usuarios",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInscripcion2",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre2",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NumeroDecimal2",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password2",
                table: "Usuarios",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaInscripcion2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombre2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroDecimal2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password2",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "FechaInscripcion",
                table: "Usuarios",
                newName: "InscripcionUsuario");

            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "Usuarios",
                newName: "EdadUsuario");
        }
    }
}
