using Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands;
using FluentValidation;

namespace Empresa.ProdutosApi.Domains.CQRS.Validations
{
    class ProdutoValidate : AbstractValidator<ProdutoCommand>
    {
        internal void ValidarId() =>
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O {PropertyName} não pode estar vazio!");

        internal void ValidarDescricao() =>
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A {PropertyName} não pode estar vazia!")
                .Length(3, 80).WithMessage("A {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres!");

        internal void ValidarPreco() =>
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("O {PropertyName} não pode estar vazio!")
                .GreaterThan(0).WithMessage("O {PropertyName} do Produto não pode ser zero(0)!");

        internal void ValidarAtivo() =>
            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("O {PropertyName} não pode estar vazio!");

        internal void ValidarCategoriaId() =>
            RuleFor(p => p.CategoriaId);
    }
}
