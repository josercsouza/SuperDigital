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
    public class RepositorioDeLancamento : IRepositorioDeLancamento, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeLancamento() =>
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();

        public void Adicionar(Lancamento lancamento)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<Lancamento>().Add(lancamento);
            contexto.SaveChangesAsync();
        }

        public async Task<List<Lancamento>> Obter(string contaOrigem, string contaDestino, DateTime? data = null)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            // TODO - colocar parametros de filtro
            var consulta = contexto.Set<Lancamento>().AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(contaOrigem))
                consulta = consulta.Where(x => x.ContaOrigem == contaOrigem);

            if (!string.IsNullOrEmpty(contaDestino))
                consulta = consulta.Where(x => x.ContaDestino == contaDestino);

            if (data != null)
                consulta = consulta.Where(x => x.DataEfetiva == data);

            return await consulta.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Lancamento> Obter(long id)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<Lancamento>().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
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

        ~RepositorioDeLancamento() => Dispose(false);
    }
}