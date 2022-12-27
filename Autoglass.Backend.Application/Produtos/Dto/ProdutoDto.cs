using System;

namespace Autoglass.Backend.Application.Produtos.Dto
{
    public class ProdutoDto
    {
        public long ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public long FornecedorId { get; set; }
        public string FornecedorDescricao { get; set; }
        public string FornecedorCnpj { get; set; }
    }
}
