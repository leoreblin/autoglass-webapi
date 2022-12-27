using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Core.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Backend.Application.Produtos.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Result> CreateProdutoAsync(ProdutoInputDto produto);

        Task<Result> UpdateProdutoAsync(Produto produto);
    }
}
