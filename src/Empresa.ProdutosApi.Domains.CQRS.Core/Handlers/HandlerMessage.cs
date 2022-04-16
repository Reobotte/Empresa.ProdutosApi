using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Domains.CQRS.Core.Handlers
{
    public abstract class HandlerMessage
    {
        protected readonly CancellationToken CancellationToken;
        protected readonly IMediator Mediator;

        protected HandlerMessage(CancellationToken cancellationToken, IMediator mediator)
        {
            CancellationToken = cancellationToken;
            Mediator = mediator;
        }

        public async Task ErrorIdAsync(string message, IResult result)
        {
            await Publish(message);
            result.AddError(message);
        }

        public async Task ErrorRequestAsync(ValidationResult request, IResult result)
        {
            await Publish(request);
            result.AddErrors(GetErrors(request));
        }

        private async Task Publish(string message) =>
            await Mediator.Publish(new Notification(message), CancellationToken);

        private async Task Publish(ValidationResult request) =>
            await Mediator.Publish(new Notification(request), CancellationToken);

        private static IEnumerable<string> GetErrors(ValidationResult request) =>
            request.Errors.Select(x => x.ErrorMessage);
    }
}
