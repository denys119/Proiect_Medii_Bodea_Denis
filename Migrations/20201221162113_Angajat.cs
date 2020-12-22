using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Medii_Bodea_Denis.Migrations
{
    public partial class Angajat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Masina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Masina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAngajat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaraProvenienta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_AngajatID",
                table: "Masina",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_Masina_TaraID",
                table: "Masina",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Angajat_AngajatID",
                table: "Masina",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Tara_TaraID",
                table: "Masina",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Angajat_AngajatID",
                table: "Masina");

            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Tara_TaraID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Masina_AngajatID",
                table: "Masina");

            migrationBuilder.DropIndex(
                name: "IX_Masina_TaraID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Masina");
        }
    }
}
