using Autoglass.Backend.Application.Pagination;
using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Application.Produtos.Repositories;
using Autoglass.Backend.Application.Produtos.Services.Interfaces;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.WebAPI.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Autoglass.Backend.WebAPI.Controllers
{
    [ApiController]
    public class ProdutosController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        public ProdutosController(
            IMapper mapper,
            IProdutoRepository produtoRepository,
            IProdutoService produtoService)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }

        [HttpGet("api/v1/produtos")]
        public async Task<IActionResult> GetProdutos(string filtroDescricao, int? pageNumber, int? pageSize)
        {
            var produtos = await _produtoRepository.GetAllProdutosByFiltroAsync(filtroDescricao);

            if (produtos?.Count == 0)
            {
                return NotFound("Produtos não encontrados.");
            }

            var pagingParameters = new PagingParameters();
            pagingParameters.PageNumber = pageNumber ?? 1;
            pagingParameters.PageSize = pageSize ?? 10;

            return Ok(PagedList<ProdutoDto>.GetPagedList(produtos, pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        [HttpGet("api/v1/produtos/{produtoId:long}")]
        public async Task<IActionResult> GetProdutoById(long produtoId)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(produtoId);

            if (produto == default(ProdutoDto))
            {
                return NotFound("Produto não encontrados.");
            }

            return Ok(produto);
        }

        [HttpPost("api/v1/produtos/inserir")]
        public async Task<IActionResult> CreateProduto(ProdutoInput produtoInput)
        {
            var dto = _mapper.Map<ProdutoInputDto>(produtoInput);
            var result = await _produtoService.CreateProdutoAsync(dto);

            if (result.IsFailed)
            {
                return FluentResult(result);
            }

            return Ok();
        }

        [HttpPut("api/v1/produtos/{produtoId:long}/editar")]
        public async Task<IActionResult> UpdateProduto(long produtoId, ProdutoInput produtoInput)
        {
            Produto produto = _mapper.Map<Produto>(produtoInput);
            produto.Id = produtoId;
            var result = await _produtoService.UpdateProdutoAsync(produto);

            if (result.IsFailed)
            {
                return FluentResult(result);
            }

            return Ok();
        }

        [HttpPut("api/v1/produtos/{produtoId:long}/excluir")]
        public async Task<IActionResult> DeleteProduto(long produtoId)
        {
            var produto = await _produtoRepository.GetAsync(produtoId);

            if (produto is null)
            {
                return FluentResult(Result.Fail(new Error("Não existe produto com o código informado.")), HttpStatusCode.NotFound);
            }

            produto.Ativo = false;

            var result = await _produtoService.UpdateProdutoAsync(produto);

            if (result.IsFailed)
            {
                return FluentResult(result);
            }

            return Ok();
        }
    }
}
