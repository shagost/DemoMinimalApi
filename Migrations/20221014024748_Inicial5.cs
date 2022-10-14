using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Lancamento",
                type: "decimal",
                precision: 9,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Lancamento",
                type: "decimal",
                precision: 9,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Lancamento",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Lancamento");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Lancamento",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldPrecision: 9,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Lancamento",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldPrecision: 9,
                oldScale: 2);
        }
    }
}
