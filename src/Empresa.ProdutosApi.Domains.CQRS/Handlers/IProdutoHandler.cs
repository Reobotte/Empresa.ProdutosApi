using Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using MediatR;

namespace Empresa.ProdutosApi.Domains.CQRS.Handlers
{
    interface IProdutoHandler : 
        IRequestHandler<IncluirProdutoCommand, Result>,
        IRequestHandler<AlterarProdutoCommand, Result>,
        IRequestHandler<ExcluirProdutoCommand, Result> { }
}
