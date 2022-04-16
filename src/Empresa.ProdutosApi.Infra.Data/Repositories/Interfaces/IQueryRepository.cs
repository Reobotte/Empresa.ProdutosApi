using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;

namespace Empresa.ProdutosApi.Infra.Data.Repositories.Interfaces
{
    public interface IQueryRepository<T>
        : IQueryDomain<T> where T : IEntityBase { }
}
