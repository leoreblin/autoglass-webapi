using System;

namespace Autoglass.Backend.Application.Produtos.Dto
{
    public class RequestProdutosDto
    {
        public long? ProdutoId { get; set; }
        public bool? Ativo { get; set; }
        public string DescricaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public long? FornecedorId { get; set; }
    }
}
