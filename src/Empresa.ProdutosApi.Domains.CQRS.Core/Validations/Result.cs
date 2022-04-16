using System.Collections.Generic;

namespace Empresa.ProdutosApi.Domains.CQRS.Core.Validations
{
    public class Result : IResult
    {
        private readonly List<string> _errors;
        public List<string> Errors => _errors;

        public bool HasErrors => _errors.Count > 0;

        public Result() =>
            _errors = new List<string>();

        public void AddError(string error) =>
            _errors.Add(error);

        public void AddErrors(IEnumerable<string> errors) =>
            _errors.AddRange(errors);
    }
}
