using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Autoglass.Backend.WebAPI.Models
{
    public class ProdutoInput
    {
        [Required]
        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [Required]
        [JsonProperty("dataFabricacao")]
        public DateTime DataFabricacao { get; set; }

        [Required]
        [JsonProperty("dataValidade")]
        public DateTime DataValidade { get; set; }

        [Required]
        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [Required]
        [JsonProperty("fornecedorId")]
        public int FornecedorId { get; set; }
    }
}
