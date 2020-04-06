using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;

namespace SuperDigital.Infraestrutura.Contexto
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
        }

        // SuperDigital
        //public DbSet<ContaCorrente> ContaCorrente { get; set; }

        //public DbSet<Lancamento> Lancamento { get; set; }
        // SuperDigital

        // TestesDiversos
        public DbSet<Autorizacao> Autorizacao { get; set; }

        // TestesDiversos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConectionConfig());
            }
        }

        public string StringConectionConfig()
        {
            //return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperDigital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestesDiversos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}