using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Lic.Migrations
{
    public partial class AddPret_Fel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Pret",
                table: "Fel",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Fel");
        }
    }
}
