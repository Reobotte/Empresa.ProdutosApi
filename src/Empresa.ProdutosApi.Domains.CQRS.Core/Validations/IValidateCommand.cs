using FluentValidation.Results;
using MediatR;

namespace Empresa.ProdutosApi.Domains.CQRS.Core.Validations
{
    public interface IValidateCommand : IRequest<Result>, ICommand
    {
        ValidationResult ValidationResult { get; set; }
    }
}
