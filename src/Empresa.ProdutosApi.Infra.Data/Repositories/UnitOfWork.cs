using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using Empresa.ProdutosApi.Infra.Data.ORM.EFCore;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdutoDbContext _context;

        public UnitOfWork(ProdutoDbContext context) =>
            _context = context;

        public async Task<bool> Commit() =>
            await _context.SaveChangesAsync() > 0;
    }
}
