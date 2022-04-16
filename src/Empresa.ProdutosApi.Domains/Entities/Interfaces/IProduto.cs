using Empresa.ProdutosApi.Domains.Enumerated;
using System;

namespace Empresa.ProdutosApi.Domains.Entities.Interfaces
{
    public interface IProduto : IEntityBase
    {
        string Descricao { get; }
        decimal Preco { get; }
        EnumStatus Status { get; }
        Guid? CategoriaId { get; }
    }
}
