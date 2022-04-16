using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices.Interfaces
{
    public interface IApplicationService<T>
        : IApplicationServiceBase<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);

        Task<ResultVo> Insert(T obj);
        Task<ResultVo> Update(T obj);
        Task<IResult> Delete(Guid id);
    }
}
