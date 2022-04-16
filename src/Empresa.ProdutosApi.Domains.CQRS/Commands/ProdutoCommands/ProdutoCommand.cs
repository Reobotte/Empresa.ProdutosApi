using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Domains.CQRS.Validations;
using Empresa.ProdutosApi.Domains.Entities;
using Empresa.ProdutosApi.Domains.Enumerated;
using FluentValidation.Results;
using System;

namespace Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Produto, IValidateCommand
    {
        protected ProdutoCommand(Guid id)
            : base(id) { }

        protected ProdutoCommand(string descricao, decimal preco, EnumStatus status, Guid? categoriaid)
            : base(descricao, preco, status, categoriaid) { }

        protected ProdutoCommand(Guid id, string descricao, decimal preco, EnumStatus status, Guid? categoriaid)
            : base(id, descricao, preco, status, categoriaid) { }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            ValidationResult = new ProdutoCommandValidate()
                .Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
