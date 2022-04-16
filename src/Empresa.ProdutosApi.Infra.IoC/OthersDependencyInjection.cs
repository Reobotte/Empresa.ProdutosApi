using Empresa.ProdutosApi.ApplicationServices.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Reflection;

namespace Empresa.ProdutosApi.Infra.IoC
{
    public static class OthersDependencyInjection
    {
        public static void AddOthersDependency(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Empresa.ProdutosApi.ApplicationServices"));
            services.AddMediatR(Assembly.Load("Empresa.ProdutosApi.Domains.CQRS"));

            services.AddRefitClient<ICategoriaApiService>()
                .ConfigureHttpClient(opt =>
                    opt.BaseAddress = new Uri("https://localhost:5013"));

        }
    }
}
