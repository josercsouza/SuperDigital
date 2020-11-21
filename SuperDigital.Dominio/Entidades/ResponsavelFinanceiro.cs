using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDigital.Dominio.Entidades
{
    [Table("ResponsavelFinanceiro")]
    public class ResponsavelFinanceiro
    {
        [Key]
        [Column("Codigo")]
        public Guid Codigo { get; set; }

        [Column("Nome")]
        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Column("Documento")]
        [Required, MaxLength(50)]
        public string Documento { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}