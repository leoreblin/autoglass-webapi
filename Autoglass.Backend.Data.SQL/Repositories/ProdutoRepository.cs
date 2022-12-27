using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Application.Produtos.Repositories;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.Data.SQL.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Backend.Data.SQL.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<List<ProdutoDto>> GetAllProdutosByFiltroAsync(string descricao)
        {
            string filtroProdutos = string.Empty;

            if (!string.IsNullOrEmpty(descricao))
            {
                filtroProdutos += "AND (p.[Descricao] LIKE @ProdutoDescricao) ";
            }

            var query = @$"SELECT p.[Id] AS ProdutoId,
                                  p.[Descricao] AS ProdutoDescricao,
                                  p.[Ativo],
                                  p.[DataFabricacao],
                                  p.[DataValidade],
                                  f.[Id] AS FornecedorId,
                                  f.[Descricao] AS FornecedorDescricao,
                                  f.[Cnpj] AS FornecedorCnpj
                            FROM [dbo].[Produto] p
                           INNER JOIN [dbo].[Fornecedor] f ON p.[FornecedorId] = f.[Id]
                           WHERE 1=1
                           {filtroProdutos}
                           ORDER BY p.[Id]";

            using var connection = _connectionFactory.GetOpenConnection();

            var produtos = await connection.QueryAsync<ProdutoDto>(query, new { ProdutoDescricao = "%" + descricao + "%" });

            return produtos.ToList();
        }

        public async Task<ProdutoDto> GetProdutoByIdAsync(long produtoId)
        {
            var query = @$"SELECT p.[Id] AS ProdutoId,
                                  p.[Descricao] AS ProdutoDescricao,
                                  p.[Ativo],
                                  p.[DataFabricacao],
                                  p.[DataValidade],
                                  f.[Id] AS FornecedorId,
                                  f.[Descricao] AS FornecedorDescricao,
                                  f.[Cnpj] AS FornecedorCnpj
                            FROM [dbo].[Produto] p
                           INNER JOIN [dbo].[Fornecedor] f ON p.[FornecedorId] = f.[Id]
                           WHERE p.[Id] = @ProdutoId
                           ORDER BY p.[Id]";

            using var connection = _connectionFactory.GetOpenConnection();

            return await connection.QueryFirstAsync<ProdutoDto>(query, new { ProdutoId = produtoId });
        }
    }
}
