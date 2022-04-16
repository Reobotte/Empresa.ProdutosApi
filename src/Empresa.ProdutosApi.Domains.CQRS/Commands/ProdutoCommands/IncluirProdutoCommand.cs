using Empresa.ProdutosApi.Domains.Enumerated;
using System;

namespace Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands
{
    public class IncluirProdutoCommand : ProdutoCommand
    {
        public IncluirProdutoCommand(string descricao, decimal preco, EnumStatus status, Guid? categoriaid) 
            : base(descricao, preco, status, categoriaid) { }
    }
}
