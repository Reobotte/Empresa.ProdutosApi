using Empresa.ProdutosApi.Domains.Entities;
using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using Empresa.ProdutosApi.Infra.Data.ORM.EFCore;
using Empresa.ProdutosApi.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Infra.Data.Repositories
{
    public class ProdutoRepository
        : Repository<Produto>, IProdutoRepository,
        IProdutoQueryRepository, IProdutoQueryDomain
    {
        public ProdutoRepository(ProdutoDbContext context) 
            : base(context) { }

        #region Query

        async Task<IEnumerable<IProduto>> IQueryDomain<IProduto>.GetAll() =>
            await base.GetAll();

        async Task<IProduto> IQueryDomain<IProduto>.Get(Guid id) =>
            await base.Get(id);

        #endregion

        #region CRUD

        public void Insert(IProduto obj) =>
            base.Insert((Produto) obj);

        public void Update(IProduto obj) =>
            base.Update((Produto)obj);

        public void Delete(IProduto obj) =>
            base.Delete((Produto)obj);

        #endregion
    }
}
