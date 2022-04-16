using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.ProdutosApi.Infra.Data.Migrations
{
    public partial class AddEmpresaProdutosApiProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    produto_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    produto = table.Column<string>(type: "VarChar(80)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.produto_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_produto_produto",
                table: "produto",
                column: "produto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
