using System;

namespace Autoglass.Backend.Application.Produtos.Dto
{
    public class ProdutoInputDto
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public long FornecedorId { get; set; }
    }
}
