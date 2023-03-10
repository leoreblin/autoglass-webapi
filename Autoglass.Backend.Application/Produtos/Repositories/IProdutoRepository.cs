using Autoglass.Backend.Application.Pagination;
using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Backend.Application.Produtos.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<ProdutoDto>> GetAllProdutosByFiltroAsync(string descricao);

        Task<ProdutoDto> GetProdutoByIdAsync(long produtoId);
    }
}
