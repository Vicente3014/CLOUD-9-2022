using Microsoft.EntityFrameworkCore.Migrations;

namespace CLOUD_DATA.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Fatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_ID",
                table: "Fatura",
                column: "ID");

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

            migrationBuilder.DropIndex(
                name: "IX_Fatura_ID",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Fatura");
        }
    }
}
