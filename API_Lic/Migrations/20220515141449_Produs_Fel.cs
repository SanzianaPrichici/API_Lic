using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Lic.Migrations
{
    public partial class Produs_Fel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durata = table.Column<float>(type: "real", nullable: false),
                    InStoc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<float>(type: "real", nullable: false),
                    Alergen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fel");

            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
