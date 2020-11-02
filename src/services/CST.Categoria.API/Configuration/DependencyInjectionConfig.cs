using CST.Categoria.API.Data;
using CST.Categoria.API.Data.Repository;
using CST.Categoria.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Categoria.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<CategoriaContext>();
        }
    }
}