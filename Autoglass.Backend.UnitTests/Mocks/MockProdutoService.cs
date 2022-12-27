using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Application.Produtos.Services.Interfaces;
using Autoglass.Backend.Core.Entities;
using FluentResults;
using Moq;
using System.Threading.Tasks;

namespace Autoglass.Backend.UnitTests.Mocks
{
    public class MockProdutoService : Mock<IProdutoService>
    {
        public MockProdutoService() : base(MockBehavior.Strict) { }

        public MockProdutoService MockCreateProdutoAsync(ProdutoInputDto produtoInput, Result output)
        {
            Setup(m => m.CreateProdutoAsync(produtoInput))
                .Returns(Task.FromResult(output));

            return this;
        }

        public MockProdutoService MockUpdateProdutoAsync(Produto produto, Result output)
        {
            Setup(m => m.UpdateProdutoAsync(produto))
                .Returns(Task.FromResult(output));

            return this;
        }
    }
}
