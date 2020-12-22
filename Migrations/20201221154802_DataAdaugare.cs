using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Medii_Bodea_Denis.Migrations
{
    public partial class DataAdaugare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugare",
                table: "Masina",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdaugare",
                table: "Masina");
        }
    }
}
