using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvojFilm.Services.Migrations
{
    public partial class popravka_Filmovi_tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmoviKomentari_Filmovi_Knjiga_ID",
                table: "FilmoviKomentari");

            migrationBuilder.RenameColumn(
                name: "Knjiga_ID",
                table: "FilmoviKomentari",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmoviKomentari_Knjiga_ID",
                table: "FilmoviKomentari",
                newName: "IX_FilmoviKomentari_FilmId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Poster",
                table: "Filmovi",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FilmFile",
                table: "Filmovi",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmoviKomentari_Filmovi_FilmId",
                table: "FilmoviKomentari",
                column: "FilmId",
                principalTable: "Filmovi",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmoviKomentari_Filmovi_FilmId",
                table: "FilmoviKomentari");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmoviKomentari",
                newName: "Knjiga_ID");

            migrationBuilder.RenameIndex(
                name: "IX_FilmoviKomentari_FilmId",
                table: "FilmoviKomentari",
                newName: "IX_FilmoviKomentari_Knjiga_ID");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Poster",
                table: "Filmovi",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "FilmFile",
                table: "Filmovi",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmoviKomentari_Filmovi_Knjiga_ID",
                table: "FilmoviKomentari",
                column: "Knjiga_ID",
                principalTable: "Filmovi",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
