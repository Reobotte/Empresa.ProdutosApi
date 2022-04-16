using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.ProdutosApi.Infra.Data.Migrations
{
    public partial class AddEmpresaProdutosApiProdutoCategoriaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "categoria_id",
                table: "produto",
                type: "varchar(36)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria_id",
                table: "produto");
        }
    }
}
