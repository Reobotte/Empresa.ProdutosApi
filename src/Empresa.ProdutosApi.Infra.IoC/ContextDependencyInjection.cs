using Empresa.ProdutosApi.Infra.Data.ORM.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.ProdutosApi.Infra.IoC
{
    public static class ContextDependencyInjection
    {
        public static void AddContextDependency(
            this IServiceCollection services, IConfiguration configuration) =>
                services.AddDbContext<ProdutoDbContext>(opt => opt.UseMySql(configuration["ConnectionStrings:ProdutoConnection"]));
    }
}
