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

        public DbSet<ResponsavelFinanceiro> ResponsavelFinanceiro { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
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
            // SuperDigital
            //return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperDigital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // TestesDiversos
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestesDiversos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponsavelFinanceiro>()
                .HasOne(a => a.Endereco)
                .WithOne(b => b.ResponsavelFinanceiro)
                .HasForeignKey<Endereco>(b => b.CodigoDoResponsavelFinanceiro);
        }
    }
}