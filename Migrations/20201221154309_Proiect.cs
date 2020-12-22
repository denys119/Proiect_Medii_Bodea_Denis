using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Medii_Bodea_Denis.Migrations
{
    public partial class Proiect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Culoare = table.Column<string>(nullable: true),
                    An = table.Column<int>(nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masina", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masina");
        }
    }
}
