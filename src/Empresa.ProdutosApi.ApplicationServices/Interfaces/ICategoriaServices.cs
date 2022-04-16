using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices.Interfaces
{
    public interface ICategoriaServices
    {
        Task<IEnumerable<CategoriaVo>> GetAll();
        Task<CategoriaVo> Get(Guid id);
    }
}
