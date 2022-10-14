using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Migrations
{
    public partial class Inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Lancamento",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Lancamento");
        }
    }
}
