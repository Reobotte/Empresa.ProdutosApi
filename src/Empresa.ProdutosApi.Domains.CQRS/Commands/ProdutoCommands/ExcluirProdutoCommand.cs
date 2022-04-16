using Empresa.ProdutosApi.Domains.CQRS.Validations;
using System;

namespace Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands
{
    public class ExcluirProdutoCommand : ProdutoCommand
    {
        public ExcluirProdutoCommand(Guid id) 
            : base(id) { }

        public override bool IsValid()
        {
            var validacao = new ProdutoValidate();
            validacao.ValidarId();

            ValidationResult = validacao.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
