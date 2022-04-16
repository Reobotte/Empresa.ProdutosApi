using Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Domains.CQRS.Validations;
using Empresa.ProdutosApi.Domains.Entities;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Domains.CQRS.Handlers
{
    class Handler 
        : IProdutoHandler
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _repository;
        private readonly IProdutoQueryDomain _query;
        private readonly IUnitOfWork _unitOfWork;        

        public Handler(
            IMediator mediator,
            IProdutoRepository repository,
            IProdutoQueryDomain query,
            IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repository = repository;
            _query = query;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(IncluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        public async Task<Result> Handle(AlterarProdutoCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        public async Task<Result> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        private async Task<Result> ProdutoResult(IValidateCommand request, CancellationToken cancellationToken) =>
            await new ProdutoHandler(
                repository: _repository,
                repositoryQueryBase: _query,
                validateCommand: request,
                cancellationToken: cancellationToken,
                mediator: _mediator).Results();
    }
}
