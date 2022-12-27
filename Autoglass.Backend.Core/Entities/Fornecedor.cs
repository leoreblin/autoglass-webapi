using Autoglass.Backend.Domain.Core.Entities;
using Dapper.Contrib.Extensions;

namespace Autoglass.Backend.Core.Entities
{
    [Table("Fornecedor")]
    public class Fornecedor : BaseEntity
    {
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
    }
}
