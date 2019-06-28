using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDigital.Dominio.Entidades
{
    [Table("Lancamento")]
    public class Lancamento
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("DataEfetiva")]
        [Required]
        public DateTime DataEfetiva { get; set; } = DateTime.Now;

        [Column("ContaOrigem")]
        public string ContaOrigem { get; set; }

        [Column("ContaDestino")]
        public string ContaDestino { get; set; }

        [Required]
        [Column("Valor")]
        public decimal Valor { get; set; }
    }
}