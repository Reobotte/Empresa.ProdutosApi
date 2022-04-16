using Empresa.ProdutosApi.ApplicationServices.Interfaces;
using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaApiService _api;

        public CategoriaServices(ICategoriaApiService api) =>
            _api = api;

        public async Task<IEnumerable<CategoriaVo>> GetAll() =>
            await _api.GetAll();

        public async Task<CategoriaVo> Get(Guid id) =>
            await _api.Get(id);
    }
}
