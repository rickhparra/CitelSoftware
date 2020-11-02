using CST.Produtos.API.Data;
using CST.Produtos.API.Data.Repository;
using CST.Produtos.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Produtos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ProdutoContext>();
        }
    }
}