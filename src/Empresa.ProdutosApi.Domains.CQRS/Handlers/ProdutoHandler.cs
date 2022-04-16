using Empresa.ProdutosApi.Domains.CQRS.Core.Handlers;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Domains.Entities;
using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Domains.CQRS.Handlers
{
    internal class ProdutoHandler
        : HandlerMessage
    {
        private readonly IProdutoQueryDomain _query;
        private readonly IProdutoRepository _repository;
        private readonly IValidateCommand _validateCommand;

        internal ProdutoHandler(
            IProdutoRepository repository,
            IProdutoQueryDomain repositoryQueryBase,
            IValidateCommand validateCommand,
            CancellationToken cancellationToken,
            IMediator mediator)
                : base(cancellationToken, mediator)
        {
            _repository = repository;
            _query = repositoryQueryBase;
            _validateCommand = validateCommand;
        }

        internal async Task<Result> Results()
        {
            var result = new Result();
            if (_validateCommand.IsValid())
            {
                var entity = (IProduto)_validateCommand;
                await CommandsExecute<IProduto>
                    .Commands(
                        request: _validateCommand,
                        response: await _query.Get(entity.Id),
                        repository: _repository,
                        requested: new Produto(entity),
                        result: result,
                        handlerMessage: this);
            }
            else
                await ErrorRequestAsync(_validateCommand.ValidationResult, result);

            return result;
        }
    }
}
