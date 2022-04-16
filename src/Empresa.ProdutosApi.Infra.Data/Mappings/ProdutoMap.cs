using Empresa.ProdutosApi.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.ProdutosApi.Infra.Data.Mappings
{
    class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Nome da Tabela no Banco de Dados
            builder.ToTable("produto");

            // Chave Primária
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("produto_id")
                .HasColumnType("varchar(36)");

            builder.Property(x => x.Descricao)
                .HasColumnName("produto")
                .HasColumnType("VarChar(80)")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnName("preco")
                .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.Status)
                .HasColumnName("status");

            builder.Property(x => x.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("varchar(36)");

            builder.HasIndex(x => x.Descricao).IsUnique();
        }
    }
}
