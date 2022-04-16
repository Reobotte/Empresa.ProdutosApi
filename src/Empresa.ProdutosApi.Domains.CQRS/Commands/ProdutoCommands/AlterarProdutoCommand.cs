using Empresa.ProdutosApi.Domains.Enumerated;
using System;

namespace Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands
{
    public class AlterarProdutoCommand : ProdutoCommand
    {
        public AlterarProdutoCommand(Guid id, string descricao, decimal preco, EnumStatus status, Guid? categoriaid) 
            : base(id, descricao, preco, status, categoriaid) { }
    }
}
