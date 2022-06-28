using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Lic.Migrations
{
    public partial class AddStatusOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Comanda",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comanda");
        }
    }
}
