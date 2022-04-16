using Empresa.ProdutosApi.Domains.Entities.Interfaces;

namespace Empresa.ProdutosApi.Domains.Interfaces.Repository
{
    public interface ICommandRepository<T>
        : IRepository<T> where T : IEntityBase
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
