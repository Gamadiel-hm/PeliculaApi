using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculaDb.Migrations
{
    /// <inheritdoc />
    public partial class Soft_Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Peliculas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Peliculas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Peliculas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Generos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Generos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Generos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Actors",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Actors",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Actors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Actors");
        }
    }
}
