using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_TipoLancamento_TipoLancamentoId",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "TipoLancamentoId",
                table: "Lancamento",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_TipoLancamento_TipoLancamentoId",
                table: "Lancamento",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_TipoLancamento_TipoLancamentoId",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "TipoLancamentoId",
                table: "Lancamento",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_TipoLancamento_TipoLancamentoId",
                table: "Lancamento",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamento",
                principalColumn: "Id");
        }
    }
}
