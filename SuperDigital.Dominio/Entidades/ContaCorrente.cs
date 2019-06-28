using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDigital.Dominio.Entidades
{
    [Table("ContaCorrente")]
    public class ContaCorrente
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NumeroDaConta")]
        public string NumeroDaConta { get; set; }

        [Column("NomeDoCorrentista")]
        public string NomeDoCorrentista { get; set; }

        [Column("SaldoDaConta")]
        public decimal SaldoDaConta { get; set; }
    }
}