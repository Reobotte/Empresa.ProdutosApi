using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.ProdutosApi.Domains.Interfaces.Repository
{
    public interface IRepository<T>
        : IDisposable where T : IEntityBase { }
}
