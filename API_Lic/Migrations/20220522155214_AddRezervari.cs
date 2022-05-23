using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Lic.Migrations
{
    public partial class AddRezervari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CLI = table.Column<int>(type: "int", nullable: false),
                    ID_Masa = table.Column<int>(type: "int", nullable: false),
                    Suma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Masa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_pers = table.Column<int>(type: "int", nullable: false),
                    Dispo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Com = table.Column<int>(type: "int", nullable: false),
                    ID_Fel = table.Column<int>(type: "int", nullable: false),
                    Cant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Masa");

            migrationBuilder.DropTable(
                name: "Rezervare");
        }
    }
}
