using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorEntrada",
                table: "Lancamento");

            migrationBuilder.RenameColumn(
                name: "ValorSaida",
                table: "Lancamento",
                newName: "Valor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Lancamento",
                newName: "ValorSaida");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorEntrada",
                table: "Lancamento",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
