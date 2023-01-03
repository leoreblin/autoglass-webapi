using Autoglass.Backend.Core.Entities;
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

        public static implicit operator Produto(ProdutoInputDto dto)
        {
            return new Produto
            {
                Ativo = dto.Ativo,
                Descricao = dto.Descricao,
                DataFabricacao = dto.DataFabricacao,
                DataValidade = dto.DataValidade,
                FornecedorId = dto.FornecedorId
            };
        }
    }
}
