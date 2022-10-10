using Microsoft.EntityFrameworkCore.Migrations;

namespace CLOUD_DATA.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Fatura",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtigoID",
                table: "DetalhesFatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura",
                column: "ID",
                principalTable: "Utilizador",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "ArtigoID",
                table: "DetalhesFatura");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Fatura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura",
                column: "ID",
                principalTable: "Utilizador",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
