using Empresa.ProdutosApi.Domains.Entities.Interfaces;

namespace Empresa.ProdutosApi.Domains.Interfaces.Repository
{
    public interface IProdutoRepository
        : ICommandRepository<IProduto> { }
}
