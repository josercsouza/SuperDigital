using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SuperDigital.Dominio.Entidades
{
    [Table("Endereco")]
    public class Endereco
    {
        [JsonIgnore]
        [Key]
        [Column("CodigoDoResponsavelFinanceiro")]
        public Guid CodigoDoResponsavelFinanceiro { get; set; }

        [Column("Logradouro")]
        [Required, MaxLength(50)]
        public string Logradouro { get; set; }

        [Column("Bairro")]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [JsonIgnore]
        public ResponsavelFinanceiro ResponsavelFinanceiro { get; set; }
    }
}