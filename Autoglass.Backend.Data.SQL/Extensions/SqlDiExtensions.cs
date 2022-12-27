using Autoglass.Backend.Application.Fornecedores.Repositories;
using Autoglass.Backend.Application.Produtos.Repositories;
using Autoglass.Backend.Data.SQL.Context;
using Autoglass.Backend.Data.SQL.Factories;
using Autoglass.Backend.Data.SQL.Interfaces;
using Autoglass.Backend.Data.SQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autoglass.Backend.Data.SQL.Extensions
{
    public static class SqlDiExtensions
    {
        public static IServiceCollection AddAutoglassSqlData(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<AutoglassContext>(options =>
                {
                    options.UseSqlServer(
                        configuration["ConnectionStrings:DefaultConnection"],
                        o =>
                        {
                            o.MigrationsHistoryTable(tableName: "__ApplicationMigrationsHistory");
                            o.CommandTimeout(30);
                        });
                })
                .AddSingleton<IConnectionFactory, ConnectionFactory>()
                .AddTransient<IProdutoRepository, ProdutoRepository>()
                .AddTransient<IFornecedorRepository, FornecedorRepository>();
        }
    }
}
