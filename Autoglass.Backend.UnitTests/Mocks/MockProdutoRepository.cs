using Autoglass.Backend.Application.Pagination;
using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Application.Produtos.Repositories;
using Autoglass.Backend.Core.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Backend.UnitTests.Mocks
{
    public class MockProdutoRepository : Mock<IProdutoRepository>
    {
        public MockProdutoRepository() : base(MockBehavior.Strict) { }

        public MockProdutoRepository MockGetAllProdutosByFiltroAsync(string descricao, List<ProdutoDto> output)
        {
            Setup(m => m.GetAllProdutosByFiltroAsync(descricao))
                .ReturnsAsync(output);

            return this;
        }

        public MockProdutoRepository MockGetProdutoByIdAsync(long id, ProdutoDto output)
        {
            Setup(m => m.GetProdutoByIdAsync(id))
                .ReturnsAsync(output);

            return this;
        }

        public MockProdutoRepository MockAddAsync(Produto produto)
        {
            Setup(m => m.AddAsync(produto))
                .Returns(Task.CompletedTask);

            return this;
        }

        public MockProdutoRepository MockUpdateAsync(Produto produto)
        {
            Setup(m => m.UpdateAsync(produto))
                .Returns(Task.CompletedTask);

            return this;
        }
    }
}
