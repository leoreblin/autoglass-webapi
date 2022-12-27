using Autoglass.Backend.Domain.Core.Entities;
using Dapper.Contrib.Extensions;
using System;

namespace Autoglass.Backend.Core.Entities
{
    [Table("Produto")]
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public long FornecedorId { get; set; }
    }
}
