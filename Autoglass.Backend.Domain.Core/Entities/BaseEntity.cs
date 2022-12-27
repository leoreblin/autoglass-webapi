using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoglass.Backend.Domain.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}