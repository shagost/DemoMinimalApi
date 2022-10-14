using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoLancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLancamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataLancamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoLancamentoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ValorEntrada = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorSaida = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_TipoLancamento_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TipoLancamento",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TipoLancamento",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 1, "Receita", "C" });

            migrationBuilder.InsertData(
                table: "TipoLancamento",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 2, "Despesa", "D" });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_TipoLancamentoId",
                table: "Lancamento",
                column: "TipoLancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "TipoLancamento");
        }
    }
}
