using Microsoft.EntityFrameworkCore.Migrations;

namespace ConexaoBD.DAL.Migrations
{
    public partial class TipoDeMorada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMorada",
                table: "Moradas");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeMorada",
                table: "Moradas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDeMorada",
                table: "Moradas");

            migrationBuilder.AddColumn<int>(
                name: "TipoMorada",
                table: "Moradas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
