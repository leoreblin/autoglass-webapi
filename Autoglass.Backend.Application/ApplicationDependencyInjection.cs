using Autoglass.Backend.Application.Produtos.Services;
using Autoglass.Backend.Application.Produtos.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Autoglass.Backend.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
            return services;
        }
    }
}
