using Autoglass.Backend.Application.Fornecedores.Repositories;
using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Application.Produtos.Repositories;
using Autoglass.Backend.Application.Produtos.Services.Interfaces;
using Autoglass.Backend.Core.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Backend.Application.Produtos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Result> CreateProdutoAsync(ProdutoInputDto dto)
        {
            if (dto.DataFabricacao >= dto.DataValidade)
            {
                return Result.Fail(new Error("A data de fabricação não pode ser maior ou igual à data de validade."));
            }

            var fornecedor = await _fornecedorRepository.GetAsync(dto.FornecedorId);

            if (fornecedor is null)
            {
                return Result.Fail(new Error("Não existe fornecedor com o código informado."));
            }

            Produto produto = MapFromDto(dto);

            await _produtoRepository.AddAsync(produto);
            return Result.Ok();
        }

        public async Task<Result> UpdateProdutoAsync(Produto produto)
        {
            var produtoFromDb = await _produtoRepository.GetAsync(produto.Id);

            if (produtoFromDb is null)
            {
                return Result.Fail(new Error("Não existe nenhum produto com o código informado."));
            }

            if (produto.DataFabricacao >= produto.DataValidade)
            {
                return Result.Fail(new Error("A data de fabricação não pode ser maior ou igual à data de validade."));
            }

            await _produtoRepository.UpdateAsync(produto);

            return Result.Ok();
        }

        private static Produto MapFromDto(ProdutoInputDto dto)
        {
            return new Produto
            {
                Descricao = dto.Descricao,
                Ativo = dto.Ativo,
                FornecedorId = dto.FornecedorId,
                DataFabricacao = dto.DataFabricacao,
                DataValidade = dto.DataValidade
            };
        }
    }
}
