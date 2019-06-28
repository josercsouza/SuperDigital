using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;

namespace SuperDIgital.Infraestrutura.Contexto
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> opcoes) : base(opcoes)
        {
            // if not exist the db -> create
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opcoesBuilder)
        {
            if (!opcoesBuilder.IsConfigured)
            {
                opcoesBuilder.UseSqlServer(StrincConectionConfig());
            }
        }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }

        public DbSet<Lancamento> Lancamento { get; set; }

        private string StrincConectionConfig()
        {
            return "Data Source=.\\SQLEXPRESS;Initial Catalog=SuperDigital;Integrated Security=False;User ID=sa;Password=123456;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}