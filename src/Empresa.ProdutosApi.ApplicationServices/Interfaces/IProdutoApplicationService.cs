using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices.Interfaces
{
    public interface IProdutoApplicationService
        : IApplicationService<ProdutoIdVo>
    {
        Task<IEnumerable<ProdutoCategoriaVo>> GetProdutosCategoria(Guid? categoriaId);
        Task<ProdutoCategoriaVo> GetProdutoCategoria(Guid id);
    }
}
