using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices.Interfaces
{
    /// <summary>
    /// Usando replite, componente para automatizar as chamdas HTTP
    /// Através de uma Interface
    /// </summary>
    public interface ICategoriaApiService
    {
        [Get("/api/Categorias/v1")]
        Task<IEnumerable<CategoriaVo>> GetAll();

        [Get("/api/Categorias/v1/{id}")]
        Task<CategoriaVo> Get([AliasAs("id")] Guid id);
    }
}
