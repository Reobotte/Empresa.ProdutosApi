using Empresa.ProdutosApi.Domains.CQRS.Core.Handlers;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Domains.CQRS.Handlers
{
    static class CommandsExecute<T>
        where T : class, IEntityBase
    {
        internal static async Task Commands(
            IValidateCommand request,
            IEntityBase response,
            ICommandRepository<T> repository,
            T requested,
            IResult result,
            HandlerMessage handlerMessage)
        {
            if (request.GetType().Name.Contains("Incluir"))
            {
                if (response == null)
                    repository.Insert(requested);
                else
                    await GetErrorAsync("Essa Solicitação já Existe!", result, handlerMessage);
            }
            else if (request.GetType().Name.Contains("Alterar"))
            {
                if (response != null)
                    repository.Update(requested);
                else
                    await GetErrorAsync("O Objeto Solicitado não Existe!", result, handlerMessage);
            }
            else if (request.GetType().Name.Contains("Excluir"))
            {
                if (response != null)
                    repository.Delete(requested);
                else
                    await GetErrorAsync("O Objeto Solicitado não Existe!", result, handlerMessage);
            }
        }

        private static async Task GetErrorAsync(
            string message,
            IResult result,
            HandlerMessage handlerMessage) =>
                await handlerMessage.ErrorIdAsync(message, (Result)result);
    }
}
