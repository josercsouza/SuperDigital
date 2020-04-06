using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDigital.Dominio.Entidades
{
    [Table("Autorizacao")]
    public class Autorizacao
    {
        [Key]
        [Required]
        [Column("Codigo")]
        public Guid Codigo { get; set; }

        [Column("CodigoDeIndentificacao")]
        [Required, MaxLength(50)]
        public string CodigoDeIndentificacao { get; set; }

        [Column("DataDeAutorizacao")]
        [Required]
        public DateTime DataDeAutorizacao { get; set; }

        [Column("DataDeExpiracao")]
        [Required]
        public DateTime DataDeExpiracao { get; set; }

        [Column("DataDeRevalidacao")]
        public DateTime? DataDeRevalidacao { get; set; }

        [Column("Validado")]
        public bool Validado { get; set; }
    }
}