using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Repositorios
{
    public class RepositorioDeContaCorrente : IRepositorioDeContaCorrente, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeContaCorrente() =>
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();

        public void Adicionar(ContaCorrente contaCorrente)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<ContaCorrente>().Add(contaCorrente);
            contexto.SaveChangesAsync();
        }

        public void Alterar(ContaCorrente contaCorrente)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<ContaCorrente>().Update(contaCorrente);
            contexto.SaveChangesAsync();
        }

        public void Excluir(ContaCorrente contaCorrente)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<ContaCorrente>().Remove(contaCorrente);
            contexto.SaveChangesAsync();
        }

        public async Task<List<ContaCorrente>> ObterPorNome(string nome)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<ContaCorrente>().AsNoTracking().Where(x => x.NomeDoCorrentista.Contains(nome)).ToListAsync().ConfigureAwait(false);
        }

        public async Task<ContaCorrente> Obter(string numeroDaConta)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<ContaCorrente>().FirstOrDefaultAsync(x => x.NumeroDaConta == numeroDaConta).ConfigureAwait(false);
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

        ~RepositorioDeContaCorrente() => Dispose(false);
    }
}