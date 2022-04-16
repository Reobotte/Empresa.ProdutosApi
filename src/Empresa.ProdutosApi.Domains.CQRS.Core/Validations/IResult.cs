using System.Collections.Generic;

namespace Empresa.ProdutosApi.Domains.CQRS.Core.Validations
{
    public interface IResult
    {
        List<string> Errors { get; }
        bool HasErrors { get; }

        void AddError(string error);
        void AddErrors(IEnumerable<string> errors);
    }
}
