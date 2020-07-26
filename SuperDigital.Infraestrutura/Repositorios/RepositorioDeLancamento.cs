using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

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
            contexto.SaveChanges();
        }

        public List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTime? data = null)
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

            return consulta.ToList();
        }

        public Lancamento Obter(long id)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return contexto.Set<Lancamento>().FirstOrDefault(x => x.Id == id);
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