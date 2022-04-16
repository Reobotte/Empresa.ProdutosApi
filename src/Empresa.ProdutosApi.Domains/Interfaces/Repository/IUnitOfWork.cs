using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Domains.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
