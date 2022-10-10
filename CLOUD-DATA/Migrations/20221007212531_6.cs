using Microsoft.EntityFrameworkCore.Migrations;

namespace CLOUD_DATA.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Fatura",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DetalhesFatura",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(nullable: false),
                    FaturaID = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco_unit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesFatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetalhesFatura_Fatura_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "Fatura",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesFatura_FaturaID",
                table: "DetalhesFatura",
                column: "FaturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura",
                column: "ID",
                principalTable: "Utilizador",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura");

            migrationBuilder.DropTable(
                name: "DetalhesFatura");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Fatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Utilizador_ID",
                table: "Fatura",
                column: "ID",
                principalTable: "Utilizador",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
