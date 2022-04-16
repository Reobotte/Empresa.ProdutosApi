using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using Empresa.ProdutosApi.Infra.Data.ORM.EFCore;

namespace Empresa.ProdutosApi.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T>
        : IRepository<T>  where T : IEntityBase
    {
        protected readonly ProdutoDbContext Context;

        protected RepositoryBase(ProdutoDbContext context) =>
            Context = context;

        public void Dispose() =>
            Context?.DisposeAsync().AsTask();
    }
}
