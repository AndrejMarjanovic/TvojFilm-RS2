using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvojFilm.Services.Migrations
{
    public partial class update_film : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDodan",
                table: "Filmovi");

            migrationBuilder.DropColumn(
                name: "FilmFile",
                table: "Filmovi");

            migrationBuilder.AddColumn<string>(
                name: "FilmLink",
                table: "Filmovi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmLink",
                table: "Filmovi");

            migrationBuilder.AddColumn<bool>(
                name: "FileDodan",
                table: "Filmovi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FilmFile",
                table: "Filmovi",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
