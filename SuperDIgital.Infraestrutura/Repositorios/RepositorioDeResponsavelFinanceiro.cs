using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Infraestrutura.Contexto;
using System;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Repositorios
{
    public class RepositorioDeResponsavelFinanceiro : IRepositorioDeResponsavelFinanceiro, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeResponsavelFinanceiro() =>
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();

        public void Adicionar(ResponsavelFinanceiro responsavelFinanceiro)
        {
            //    using var contexto = new ContextoBase(_optionsBuilder.Options);
            //    contexto.Set<Lancamento>().Add(lancamento);
            //    contexto.SaveChangesAsync();

            throw new NotImplementedException();
        }

        public async Task<ResponsavelFinanceiro> Obter(string documento)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            var v1 = await contexto.Set<ResponsavelFinanceiro>().Include("Endereco").FirstOrDefaultAsync(x => x.Documento == documento).ConfigureAwait(false);
            return v1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposed)
        {
            if (!disposed) return;
        }

        ~RepositorioDeResponsavelFinanceiro() => Dispose(false);
    }
}