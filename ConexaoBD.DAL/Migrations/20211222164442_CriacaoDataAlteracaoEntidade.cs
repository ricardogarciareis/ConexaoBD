using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConexaoBD.DAL.Migrations
{
    public partial class CriacaoDataAlteracaoEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Clientes",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Clientes");
        }
    }
}
