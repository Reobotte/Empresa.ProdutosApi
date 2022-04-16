using Empresa.ProdutosApi.ApplicationServices;
using Empresa.ProdutosApi.ApplicationServices.Interfaces;
using Empresa.ProdutosApi.Domains.Interfaces.Repository;
using Empresa.ProdutosApi.Infra.Data.Repositories;
using Empresa.ProdutosApi.Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.ProdutosApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddDependency(
            this IServiceCollection services)
        {
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoQueryRepository, ProdutoRepository>();
            services.AddScoped<IProdutoQueryDomain, ProdutoRepository>();

            services.AddScoped<ICategoriaServices, CategoriaServices>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
