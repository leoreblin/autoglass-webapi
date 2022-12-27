using Autoglass.Backend.Application.Pagination;
using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.UnitTests.Mocks;
using Autoglass.Backend.WebAPI.Controllers;
using Autoglass.Backend.WebAPI.Models;
using Bogus;
using FizzWare.NBuilder;
using FluentAssertions;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Autoglass.Backend.UnitTests.WebAPI.Controllers
{
    public class ProdutosControllerTests
    {
        private readonly MockAutoMapper _mapper;
        private readonly MockProdutoRepository _mockProdutoRepository;
        private readonly MockProdutoService _mockProdutoService;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            _mapper = new MockAutoMapper();
            _mockProdutoRepository = new MockProdutoRepository();
            _mockProdutoService = new MockProdutoService();

            _controller = new ProdutosController(
                _mapper.Object,
                _mockProdutoRepository.Object,
                _mockProdutoService.Object);
        }

        [Fact]
        public async Task Should_GetProdutos_ReturnOk()
        {
            // Arrange
            var filtroDescricao = string.Empty;

            var pagingParameters = new PagingParameters();

            var fakeProdutos = new List<ProdutoDto>
            {
                new ProdutoDto
                {
                    Ativo = true,
                    FornecedorId = 1,
                    FornecedorCnpj = "1234",
                    FornecedorDescricao = "Fornecedor Teste 1",
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddMonths(4),
                    ProdutoDescricao = "Produto Teste 1"
                },
                new ProdutoDto
                {
                    Ativo = true,
                    FornecedorId = 1,
                    FornecedorCnpj = "1234",
                    FornecedorDescricao = "Fornecedor Teste 1",
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddMonths(4),
                    ProdutoDescricao = "Produto Teste 2"
                },
                new ProdutoDto
                {
                    Ativo = true,
                    FornecedorId = 1,
                    FornecedorCnpj = "1234",
                    FornecedorDescricao = "Fornecedor Teste 1",
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddMonths(4),
                    ProdutoDescricao = "Produto Teste 3"
                }
            };

            _mockProdutoRepository
                .MockGetAllProdutosByFiltroAsync(filtroDescricao, fakeProdutos);

            // Act
            var response = await _controller.GetProdutos(filtroDescricao, pagingParameters.PageNumber, pagingParameters.PageSize);

            // Assert
            var result = response as ObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(2, 20)]
        [InlineData(1, 100)]
        public async Task Should_GetProdutos_WithPagination_ReturnOk(int? pageNumber, int? pageSize)
        {
            // Arrange
            var filtroDescricao = string.Empty;

            var fakeProdutos = new Faker<ProdutoDto>()
                .Rules((f, p) =>
                {
                    p.Ativo = true;
                    p.FornecedorId = 1;
                    p.FornecedorCnpj = "1234";
                    p.FornecedorDescricao = "Fornecedor Unico";
                    p.DataFabricacao = DateTime.Now;
                    p.DataValidade = DateTime.Now.AddMonths(5);
                    p.ProdutoDescricao = f.Name.Random.ToString();
                })
                .Generate(200);

            _mockProdutoRepository
                .MockGetAllProdutosByFiltroAsync(filtroDescricao, fakeProdutos);

            // Act
            var response = await _controller.GetProdutos(filtroDescricao, pageNumber, pageSize);

            // Assert
            var result = response as ObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            var list = result.Value as PagedList<ProdutoDto>;
            list.Should().HaveCountLessThanOrEqualTo(PagingParameters.maxPageSize);
        }

        [Fact]
        public async Task Should_GetProdutos_ReturnNotFound()
        {
            // Arrange
            var filtroDescricao = string.Empty;

            var pagingParameters = new PagingParameters();

            var fakeProdutos = new List<ProdutoDto>();

            _mockProdutoRepository
                .MockGetAllProdutosByFiltroAsync(filtroDescricao, fakeProdutos);

            // Act
            var response = await _controller.GetProdutos(filtroDescricao, pagingParameters.PageNumber, pagingParameters.PageSize);

            // Assert
            var result = response as ObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Should_GetProdutoById_ReturnOk()
        {
            // Arrange
            var produtoId = 1;

            var fakeProduto = new ProdutoDto
            {
                Ativo = true,
                FornecedorId = 2,
                FornecedorCnpj = "5678",
                FornecedorDescricao = "Fornecedor Teste 2",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddMonths(4),
                ProdutoDescricao = "Produto Teste 2",
                ProdutoId = 1
            };

            _mockProdutoRepository
                .MockGetProdutoByIdAsync(produtoId, fakeProduto);

            // Act
            var response = await _controller.GetProdutoById(produtoId);

            // Assert
            var result = response as ObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Should_CreateProduto_ReturnOk()
        {
            // Assert
            var input = new ProdutoInput
            {
                Ativo = true,
                Descricao = "Novo produto",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1),
                FornecedorId = 1
            };

            var dto = new ProdutoInputDto
            {
                Descricao = input.Descricao,
                Ativo = input.Ativo,
                DataFabricacao = input.DataFabricacao,
                DataValidade = input.DataValidade,
                FornecedorId = input.FornecedorId
            };

            _mapper.MockMap(input, dto);
            _mockProdutoService.MockCreateProdutoAsync(dto, Result.Ok());

            // Act
            var response = await _controller.CreateProduto(input);

            // Assert
            var result = response as OkResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }



        [Fact]
        public async Task Should_UpdateProduto_ReturnOk()
        {
            // Assert
            long produtoId = 1234;

            var input = new ProdutoInput
            {
                Ativo = true,
                Descricao = "Novo produto",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1),
                FornecedorId = 1
            };

            var produto = new Produto
            {
                Descricao = input.Descricao,
                Ativo = input.Ativo,
                DataFabricacao = input.DataFabricacao,
                DataValidade = input.DataValidade,
                FornecedorId = input.FornecedorId
            };

            _mapper.MockMap(input, produto);
            _mockProdutoService.MockUpdateProdutoAsync(produto, Result.Ok());

            // Act
            var response = await _controller.UpdateProduto(produtoId, input);

            // Assert
            var result = response as OkResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
