using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;

namespace Empresa.ProdutosApi.Domains.CQRS.Core.Validations
{
    class Notification : INotification
    {
        internal readonly string Message;

        internal Notification(string message) =>
            Message = message;

        internal Notification(ValidationResult result) =>
            Message = string.Join(Environment.NewLine, result.Errors?
                    .Select(x => x.ErrorMessage));
    }
}
