using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.ProdutosApi.ApplicationServices.Interfaces
{
    public interface IApplicationServiceBase<T>
        : IDisposable where T : IEntityBase { }
}
